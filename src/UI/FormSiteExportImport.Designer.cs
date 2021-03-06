﻿namespace OnlineContentDownloader
{
    partial class FormSiteExportImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerStatus = new System.Windows.Forms.SplitContainer();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.chkVerboseLog = new System.Windows.Forms.CheckBox();
            this.panelTopSplitter = new System.Windows.Forms.Panel();
            this.txtPathToSecrets = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProvisionSite = new System.Windows.Forms.Button();
            this.txtPathToFileProvisioningConfig = new System.Windows.Forms.TextBox();
            this.btnProvisionFromAzureAd = new System.Windows.Forms.Button();
            this.txtPathToAzureAdProvisioningConfig = new System.Windows.Forms.TextBox();
            this.textBoxCommandLineExample = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).BeginInit();
            this.splitContainerStatus.Panel1.SuspendLayout();
            this.splitContainerStatus.Panel2.SuspendLayout();
            this.splitContainerStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerStatus
            // 
            this.splitContainerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerStatus.Location = new System.Drawing.Point(6, 358);
            this.splitContainerStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerStatus.Name = "splitContainerStatus";
            // 
            // splitContainerStatus.Panel1
            // 
            this.splitContainerStatus.Panel1.Controls.Add(this.textBoxStatus);
            // 
            // splitContainerStatus.Panel2
            // 
            this.splitContainerStatus.Panel2.Controls.Add(this.textBoxErrors);
            this.splitContainerStatus.Panel2.Controls.Add(this.chkVerboseLog);
            this.splitContainerStatus.Size = new System.Drawing.Size(1420, 370);
            this.splitContainerStatus.SplitterDistance = 905;
            this.splitContainerStatus.TabIndex = 18;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.BackColor = System.Drawing.Color.White;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(901, 365);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.Text = "not yet started...";
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textBoxErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxErrors.Location = new System.Drawing.Point(3, 0);
            this.textBoxErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxErrors.Multiline = true;
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxErrors.Size = new System.Drawing.Size(508, 365);
            this.textBoxErrors.TabIndex = 8;
            this.textBoxErrors.Text = "no errors yet...";
            // 
            // chkVerboseLog
            // 
            this.chkVerboseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerboseLog.AutoSize = true;
            this.chkVerboseLog.Checked = true;
            this.chkVerboseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerboseLog.Location = new System.Drawing.Point(301, 332);
            this.chkVerboseLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkVerboseLog.Name = "chkVerboseLog";
            this.chkVerboseLog.Size = new System.Drawing.Size(170, 23);
            this.chkVerboseLog.TabIndex = 11;
            this.chkVerboseLog.Text = "Verbose logging";
            this.chkVerboseLog.UseVisualStyleBackColor = true;
            // 
            // panelTopSplitter
            // 
            this.panelTopSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTopSplitter.Location = new System.Drawing.Point(-940, 58);
            this.panelTopSplitter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTopSplitter.Name = "panelTopSplitter";
            this.panelTopSplitter.Size = new System.Drawing.Size(2815, 1);
            this.panelTopSplitter.TabIndex = 59;
            this.panelTopSplitter.Visible = false;
            // 
            // txtPathToSecrets
            // 
            this.txtPathToSecrets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathToSecrets.Location = new System.Drawing.Point(136, 11);
            this.txtPathToSecrets.Name = "txtPathToSecrets";
            this.txtPathToSecrets.Size = new System.Drawing.Size(1290, 26);
            this.txtPathToSecrets.TabIndex = 64;
            this.txtPathToSecrets.Text = "<<Path to the secrets file...>>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 66;
            this.label2.Text = "Secrets path";
            // 
            // btnProvisionSite
            // 
            this.btnProvisionSite.ForeColor = System.Drawing.Color.Blue;
            this.btnProvisionSite.Location = new System.Drawing.Point(6, 58);
            this.btnProvisionSite.Name = "btnProvisionSite";
            this.btnProvisionSite.Size = new System.Drawing.Size(278, 45);
            this.btnProvisionSite.TabIndex = 67;
            this.btnProvisionSite.Text = "Provision from file manifest";
            this.btnProvisionSite.UseVisualStyleBackColor = true;
            this.btnProvisionSite.Click += new System.EventHandler(this.btnProvisionSiteFromManifestFile_Click);
            // 
            // txtPathToFileProvisioningConfig
            // 
            this.txtPathToFileProvisioningConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathToFileProvisioningConfig.Location = new System.Drawing.Point(296, 68);
            this.txtPathToFileProvisioningConfig.Name = "txtPathToFileProvisioningConfig";
            this.txtPathToFileProvisioningConfig.Size = new System.Drawing.Size(1130, 26);
            this.txtPathToFileProvisioningConfig.TabIndex = 68;
            this.txtPathToFileProvisioningConfig.Text = "<<Path to the file based provisioning...>>";
            // 
            // btnProvisionFromAzureAd
            // 
            this.btnProvisionFromAzureAd.ForeColor = System.Drawing.Color.Blue;
            this.btnProvisionFromAzureAd.Location = new System.Drawing.Point(6, 122);
            this.btnProvisionFromAzureAd.Name = "btnProvisionFromAzureAd";
            this.btnProvisionFromAzureAd.Size = new System.Drawing.Size(278, 47);
            this.btnProvisionFromAzureAd.TabIndex = 72;
            this.btnProvisionFromAzureAd.Text = "Provision from AzureAD";
            this.btnProvisionFromAzureAd.UseVisualStyleBackColor = true;
            this.btnProvisionFromAzureAd.Click += new System.EventHandler(this.btnProvisionFromAzureAd_Click);
            // 
            // txtPathToAzureAdProvisioningConfig
            // 
            this.txtPathToAzureAdProvisioningConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathToAzureAdProvisioningConfig.Location = new System.Drawing.Point(296, 133);
            this.txtPathToAzureAdProvisioningConfig.Name = "txtPathToAzureAdProvisioningConfig";
            this.txtPathToAzureAdProvisioningConfig.Size = new System.Drawing.Size(1130, 26);
            this.txtPathToAzureAdProvisioningConfig.TabIndex = 73;
            this.txtPathToAzureAdProvisioningConfig.Text = "<<Path to the Azure based provisioning...>>";
            // 
            // textBoxCommandLineExample
            // 
            this.textBoxCommandLineExample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommandLineExample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBoxCommandLineExample.ForeColor = System.Drawing.Color.White;
            this.textBoxCommandLineExample.Location = new System.Drawing.Point(6, 217);
            this.textBoxCommandLineExample.Multiline = true;
            this.textBoxCommandLineExample.Name = "textBoxCommandLineExample";
            this.textBoxCommandLineExample.ReadOnly = true;
            this.textBoxCommandLineExample.Size = new System.Drawing.Size(1420, 115);
            this.textBoxCommandLineExample.TabIndex = 74;
            this.textBoxCommandLineExample.Text = "Example command line will get generated here";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 19);
            this.label1.TabIndex = 75;
            this.label1.Text = "Command line (copy/paste from here)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 76;
            this.label3.Text = "Output logs";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(1178, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 19);
            this.label4.TabIndex = 77;
            this.label4.Text = "Errors / Unexpected";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormSiteExportImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1433, 734);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCommandLineExample);
            this.Controls.Add(this.txtPathToAzureAdProvisioningConfig);
            this.Controls.Add(this.btnProvisionFromAzureAd);
            this.Controls.Add(this.txtPathToFileProvisioningConfig);
            this.Controls.Add(this.btnProvisionSite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathToSecrets);
            this.Controls.Add(this.panelTopSplitter);
            this.Controls.Add(this.splitContainerStatus);
            this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FormSiteExportImport";
            this.Text = "Online - TabProvision, site user/roles/auth/groups provisioning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerStatus.Panel1.ResumeLayout(false);
            this.splitContainerStatus.Panel1.PerformLayout();
            this.splitContainerStatus.Panel2.ResumeLayout(false);
            this.splitContainerStatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).EndInit();
            this.splitContainerStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerStatus;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.CheckBox chkVerboseLog;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Panel panelTopSplitter;
        private System.Windows.Forms.TextBox txtPathToSecrets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProvisionSite;
        private System.Windows.Forms.TextBox txtPathToFileProvisioningConfig;
        private System.Windows.Forms.Button btnProvisionFromAzureAd;
        private System.Windows.Forms.TextBox txtPathToAzureAdProvisioningConfig;
        private System.Windows.Forms.TextBox textBoxCommandLineExample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

