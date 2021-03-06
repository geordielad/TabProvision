﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Provision a site
/// </summary>
internal partial class ProvisionSite
{


    /// <summary>
    /// Compare the list of users on the Server Site with the provision list of users and make the necessary updates
    /// </summary>
    /// <param name="existingSiteUsers"></param>
    private void Execute_ProvisionUsers(TableauServerSignIn siteSignIn)
    {

        _statusLogs.AddStatusHeader("Provision users/roles in site");
        //=================================================================================
        //Load the set of users for the site...
        //=================================================================================
        var existingUsers = DownloadUsersList.CreateAndExecute(siteSignIn);

        //Keep a list of the remaining users
        var workingListUnexaminedUsers = new WorkingListSiteUsers(existingUsers.Users);

        //==============================================================================
        //Go through each user in our "to provision" list and see if we need to
        //   1. Add them as a new user
        //   2. Update an exisitng user
        //==============================================================================
        _statusLogs.AddStatusHeader("Process explicit users list");
        foreach (var userToProvision in _provisionInstructions.UsersToProvision)
        {
            try
            {
                Execute_ProvisionUsers_SingleUser(userToProvision, siteSignIn, workingListUnexaminedUsers);
            }
            catch (Exception ex)
            {
                _statusLogs.AddError("Error provisioning user " + userToProvision.UserName + ", " + ex.Message);
                CSVRecord_Error(userToProvision.UserName, userToProvision.UserRole, userToProvision.UserAuthentication, "Error provisioning user " + userToProvision.UserName + ", " + ex.Message);
            }

            //If the user was in the working list of users on the site, then remove them (since we have looked at them)
            workingListUnexaminedUsers.RemoveUser(userToProvision.UserName);
        }

        //============================================================================================
        //Examine all the remaining users and decide if we need to delete them
        //============================================================================================
        _statusLogs.AddStatusHeader("Process unexpected users list");
        foreach (var unexpectedUser in workingListUnexaminedUsers.GetUsers())
        {
            try
            {
                Execute_UpdateUnexpectedUsersProvisioning_SingleUser(unexpectedUser, siteSignIn);
            }
            catch (Exception exUnxpectedUsers)
            {
                _statusLogs.AddError("Error processing unexpected user " + unexpectedUser.ToString() + ", " + exUnxpectedUsers.Message);
                CSVRecord_Error(unexpectedUser.Name, unexpectedUser.SiteRole, unexpectedUser.SiteAuthentication, "Error processing unexpected user " + unexpectedUser.ToString() + ", " + exUnxpectedUsers.Message);
            }
        }
    }

    /// <summary>
    /// Update the provisioning status for a single unexpected user
    /// </summary>
    /// <param name="unexpectedUser"></param>
    /// <param name="siteSignIn"></param>
    private void Execute_UpdateUnexpectedUsersProvisioning_SingleUser(SiteUser unexpectedUser, TableauServerSignIn siteSignIn)
    {
        _statusLogs.AddStatus("Process unexpected user: " + unexpectedUser.ToString());
        switch (unexpectedUser.SiteAuthenticationParsed)
        {
            case SiteUserAuth.Default:
                Execute_UpdateUnexpectedUsersProvisioning_SingleUser_WithBehavior(unexpectedUser, siteSignIn, _provisionInstructions.ActionForUnexpectedDefaultAuthUsers);
                break;
            case SiteUserAuth.SAML:
                Execute_UpdateUnexpectedUsersProvisioning_SingleUser_WithBehavior(unexpectedUser, siteSignIn, _provisionInstructions.ActionForUnexpectedSamlUsers);
                break;
            default:
                IwsDiagnostics.Assert(false, "811-1123: Unknown authentication type " + unexpectedUser.SiteAuthentication + ", for user " + unexpectedUser.Name);
                _statusLogs.AddError("811-1123: Unknown authentication type " + unexpectedUser.SiteAuthentication + ", for user " + unexpectedUser.Name);
                break;
        }
    }

    /// <summary>
    /// Handle the provisioning for a single user
    /// </summary>
    /// <param name="userToProvision"></param>
    /// <param name="siteSignIn"></param>
    /// <param name="workingListUnexaminedUsers"></param>
    private void Execute_ProvisionUsers_SingleUser(
        ProvisioningUser userToProvision,
        TableauServerSignIn siteSignIn,
        WorkingListSiteUsers workingListUnexaminedUsers)
    {
        //See if a user with this name already exists
        var foundExistingUser = workingListUnexaminedUsers.FindUser(userToProvision.UserName);

        ProvisionUserInstructions.MissingUserAction missingUserAction;
        ProvisionUserInstructions.UnexpectedUserAction unexpectedUserAction;

        //Get the instructions based on the desired Auth model for the user we are provisioning
        switch (userToProvision.UserAuthenticationParsed)
        {
            case SiteUserAuth.Default:
                missingUserAction = _provisionInstructions.ActionForMissingDefaultAuthUsers;
                unexpectedUserAction = _provisionInstructions.ActionForUnexpectedDefaultAuthUsers;
                break;
            case SiteUserAuth.SAML:
                missingUserAction = _provisionInstructions.ActionForMissingSamlUsers;
                unexpectedUserAction = _provisionInstructions.ActionForUnexpectedSamlUsers;
                break;
            default:
                IwsDiagnostics.Assert(false, "814-1204: Unknown auth type");
                throw new Exception("814-1204: Unknown auth type");
        }

        //CASE 1: The user does NOT exist.  So add them
        if (foundExistingUser == null)
        {

            Execute_ProvisionUsers_SingleUser_AddUser(siteSignIn, userToProvision, missingUserAction);
            return;
        }

        //CASE 2: The user EXISTS but is not the right role or auth; update them
        if (
            (string.Compare(foundExistingUser.SiteRole, userToProvision.UserRole, true) != 0)
            || (string.Compare(foundExistingUser.SiteAuthentication, userToProvision.UserAuthentication, true) != 0)
          )

        {
            Execute_ProvisionUsers_SingleUser_ModifyUser(siteSignIn, userToProvision, foundExistingUser);
            return;
        }

        //CASE 3: The user exists and does NOT need to be modified
        _statusLogs.AddStatus("No action: User exists and has expected role and authentication. User: " + userToProvision.UserName);
    }

    /// <summary>
    /// The MODIDFY-Existing user path for user provisioning
    /// </summary>
    /// <param name="siteSignIn"></param>
    /// <param name="userToProvision"></param>
    /// <param name="missingUserAction"></param>
    private void Execute_ProvisionUsers_SingleUser_ModifyUser(TableauServerSignIn siteSignIn, ProvisioningUser userToProvision, SiteUser existingUser)
    {
        ProvisionUserInstructions.ExistingUserAction existingUserAction;
        switch(existingUser.SiteAuthenticationParsed)
        {
            case SiteUserAuth.Default:
                existingUserAction = _provisionInstructions.ActionForExistingDefaultAuthUsers;
                break;
            case SiteUserAuth.SAML:
                existingUserAction = _provisionInstructions.ActionForExistingSamlUsers;
                break;
            default:
                IwsDiagnostics.Assert(false, "814-1234: Unknown user auth type");
                throw new Exception("814-1234: Unknown user auth type");
        }

        switch(existingUserAction)
        {
            //Modify the existing user
            case ProvisionUserInstructions.ExistingUserAction.Modify:
                _statusLogs.AddStatus("Update user: User exists but role or auth differs. Update: " + userToProvision.UserName);
                var updateUser = new SendUpdateUser(
                    siteSignIn.ServerUrls,
                    siteSignIn,
                    existingUser.Id,
                    userToProvision.UserRole,
                    userToProvision.UserAuthenticationParsed);

                var userUpdated = updateUser.ExecuteRequest();

                //-------------------------------------------------------------------------------
                //Record the action in an output file
                //-------------------------------------------------------------------------------
                CSVRecord_UserModified(
                    userToProvision.UserName,
                    userToProvision.UserRole,
                    userToProvision.UserAuthentication,
                    "existing/modified",
                    existingUser.SiteRole + "->" + userUpdated.SiteRole + ", " + existingUser.SiteAuthentication + "->" + userUpdated.SiteAuthentication);
                return;

            //Don't modify, but report
            case ProvisionUserInstructions.ExistingUserAction.Report:
                //-------------------------------------------------------------------------------
                //Record the action in an output file
                //-------------------------------------------------------------------------------
                /*                CSVRecord_Warning(
                                    userToProvision.UserName,
                                    userToProvision.UserRole,
                                    userToProvision.UserAuthentication,
                                    "Modify user: Per provisioning instructions, existing user left unaltered. " + existingUser.SiteRole + "->" + userToProvision.UserRole + ", " + existingUser.SiteAuthentication + "->" + userToProvision.UserAuthentication);
                */
                CSVRecord_UserModified(
                    userToProvision.UserName,
                    userToProvision.UserRole,
                    userToProvision.UserAuthentication,
                    "SIMULATED existing/modified",
                    existingUser.SiteRole + "->" + userToProvision.UserRole + ", " + existingUser.SiteAuthentication + "->" + userToProvision.UserAuthentication);
                return;

            default:
                IwsDiagnostics.Assert(false, "814-1237: Internal error. Unknown modify user action");
                throw new Exception("814-1237: Internal error. Unknown modify user action");
        }



    }


    /// <summary>
    /// The ADD-User path for provisioning a user
    /// </summary>
    /// <param name="siteSignIn"></param>
    /// <param name="userToProvision"></param>
    /// <param name="missingUserAction"></param>
    private void Execute_ProvisionUsers_SingleUser_AddUser(TableauServerSignIn siteSignIn, ProvisioningUser userToProvision, ProvisionUserInstructions.MissingUserAction missingUserAction)
    {
        switch(missingUserAction)
        {
            //Add the user
            case ProvisionUserInstructions.MissingUserAction.Add:
                //Setup to create a new user
                var createUser = new SendCreateUser(
                    siteSignIn.ServerUrls,
                    siteSignIn,
                    userToProvision.UserName,
                    userToProvision.UserRole,
                    userToProvision.UserAuthenticationParsed);

                var userCreated = createUser.ExecuteRequest();

                //-------------------------------------------------------------------------------
                //Record the action in an output file
                //-------------------------------------------------------------------------------
                CSVRecord_UserModified(userToProvision.UserName, userToProvision.UserRole, userToProvision.UserAuthentication, "added", "");
                return;

            //Don't add the user, just record the finding
            case ProvisionUserInstructions.MissingUserAction.Report:
                /*CSVRecord_Warning(
                    userToProvision.UserName,
                    userToProvision.UserRole,
                    userToProvision.UserAuthentication,
                    "Add user: Per provisioning instructions, unknown existing user left unaltered");
                */
                CSVRecord_UserModified(userToProvision.UserName, userToProvision.UserRole, userToProvision.UserAuthentication, "SIMULATED added", "");

                return;

            default:
                IwsDiagnostics.Assert(false, "814-1210: Unknown missing user provisioning action");
                throw new Exception("814-1210: Unknown missing user provisioning action");
        }
    }

    /// <summary>
    /// Update the unexpected user based on the specified behavior
    /// </summary>
    /// <param name="unexpectedUser"></param>
    /// <param name="siteSignIn"></param>
    /// <param name="behavior"></param>
    private void Execute_UpdateUnexpectedUsersProvisioning_SingleUser_WithBehavior(SiteUser unexpectedUser, TableauServerSignIn siteSignIn, ProvisionUserInstructions.UnexpectedUserAction behavior)
    {
        switch (behavior)
        {
            case ProvisionUserInstructions.UnexpectedUserAction.Report:
                _statusLogs.AddStatus("No action: Keep unexpected user unaltered. User: " + unexpectedUser.ToString());

                //Only file a warning if the user is NOT unlicensed
                if (unexpectedUser.SiteRoleParsed != SiteUserRole.Unlicensed)
                {
                    //-------------------------------------------------------------------------------
                    //Record the non-action in an output file
                    //-------------------------------------------------------------------------------
                    /*CSVRecord_Warning(
                        unexpectedUser.Name,
                        unexpectedUser.SiteRole,
                        unexpectedUser.SiteAuthentication,
                        "Per provisioning instructions, unknown existing user left unaltered");
                    */
                    CSVRecord_UserModified(
                        unexpectedUser.Name,
                        unexpectedUser.SiteRole,
                        unexpectedUser.SiteAuthentication,
                        "SIMULATED existing/removed",
                        unexpectedUser.SiteRole + "->" + "Unlicensed");
                        return;

                }

                return;

            case ProvisionUserInstructions.UnexpectedUserAction.Unlicense:
                //If the user is already unlicensed, then there is nothing that needs to be done
                if (unexpectedUser.SiteRoleParsed == SiteUserRole.Unlicensed)
                {
                    return;
                }

                _statusLogs.AddStatus("Unlicense unexpected user: " + unexpectedUser.ToString());
                var updateUser = new SendUpdateUser(
                    siteSignIn.ServerUrls,
                    siteSignIn,
                    unexpectedUser.Id,
                    SiteUser.Role_Unlicensed,
                    unexpectedUser.SiteAuthenticationParsed);

                var userUpdated = updateUser.ExecuteRequest();

                //-------------------------------------------------------------------------------
                //Record the action in an output file
                //-------------------------------------------------------------------------------
                CSVRecord_UserModified(
                    unexpectedUser.Name,
                    unexpectedUser.SiteRole,
                    unexpectedUser.SiteAuthentication,
                    "existing/removed",
                    unexpectedUser.SiteRole + "->" + userUpdated.SiteRole);
                return;

            default:
                IwsDiagnostics.Assert(false, "811-1130: Internal error. Unknown provisioning behavior for user " + unexpectedUser.ToString());
                _statusLogs.AddError("811-1130: Internal error. Unknown provisioning behavior for user " + unexpectedUser.ToString());
                return;
        }
    }


    /// <summary>
    /// Make a record of a user modification
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userRole"></param>
    /// <param name="userAuth"></param>
    /// <param name="modification"></param>
    /// <param name="notes"></param>
    private void CSVRecord_UserModified(string userName, string userRole, string userAuth, string modification, string notes)
    {
        _csvProvisionResults.AddKeyValuePairs(
            new string[] { "area", "user-name", "user-role", "user-auth", "modification", "notes" },
            new string[] { "user provisioning", userName, userRole, userAuth, modification, notes });
    }

}


