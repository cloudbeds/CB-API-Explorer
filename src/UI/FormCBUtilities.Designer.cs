    partial class FormCBUtilities
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
            this.txtPathToAppSecrets = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkShowDebugAsserts = new System.Windows.Forms.CheckBox();
            this.btnGenerateCBApiSecret = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathToUserTokenSecrets = new System.Windows.Forms.TextBox();
            this.btnSaveUserAuthToken = new System.Windows.Forms.Button();
            this.btnLoadUserTokenFromFile = new System.Windows.Forms.Button();
            this.blnClearLogs = new System.Windows.Forms.Button();
            this.panelAuthSessionDetails = new System.Windows.Forms.Panel();
            this.btnForceRefreshOfUserTokens = new System.Windows.Forms.Button();
            this.txtAuthSessionInfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnQueryHotelDashboard = new System.Windows.Forms.Button();
            this.btnQueryUserInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).BeginInit();
            this.splitContainerStatus.Panel1.SuspendLayout();
            this.splitContainerStatus.Panel2.SuspendLayout();
            this.splitContainerStatus.SuspendLayout();
            this.panelAuthSessionDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerStatus
            // 
            this.splitContainerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerStatus.Location = new System.Drawing.Point(6, 567);
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
            this.splitContainerStatus.Size = new System.Drawing.Size(1420, 309);
            this.splitContainerStatus.SplitterDistance = 905;
            this.splitContainerStatus.TabIndex = 18;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.BackColor = System.Drawing.Color.White;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(901, 304);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.Text = "not yet started...";
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textBoxErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxErrors.Location = new System.Drawing.Point(3, 0);
            this.textBoxErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxErrors.Multiline = true;
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxErrors.Size = new System.Drawing.Size(508, 304);
            this.textBoxErrors.TabIndex = 8;
            this.textBoxErrors.Text = "no errors yet...";
            // 
            // chkVerboseLog
            // 
            this.chkVerboseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerboseLog.AutoSize = true;
            this.chkVerboseLog.Checked = true;
            this.chkVerboseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerboseLog.Location = new System.Drawing.Point(301, 271);
            this.chkVerboseLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkVerboseLog.Name = "chkVerboseLog";
            this.chkVerboseLog.Size = new System.Drawing.Size(170, 23);
            this.chkVerboseLog.TabIndex = 11;
            this.chkVerboseLog.Text = "Verbose logging";
            this.chkVerboseLog.UseVisualStyleBackColor = true;
            // 
            // txtPathToAppSecrets
            // 
            this.txtPathToAppSecrets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathToAppSecrets.Location = new System.Drawing.Point(287, 4);
            this.txtPathToAppSecrets.Name = "txtPathToAppSecrets";
            this.txtPathToAppSecrets.Size = new System.Drawing.Size(1139, 26);
            this.txtPathToAppSecrets.TabIndex = 66;
            this.txtPathToAppSecrets.Text = "<<Path to the secrets file...>>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 19);
            this.label2.TabIndex = 66;
            this.label2.Text = "Applicattion secrets file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 76;
            this.label3.Text = "Output logs";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(1178, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 19);
            this.label4.TabIndex = 77;
            this.label4.Text = "Errors / Unexpected";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(623, 28);
            this.label5.TabIndex = 78;
            this.label5.Text = "STEP 1: Generate or Load REST API Access Tokens";
            // 
            // chkShowDebugAsserts
            // 
            this.chkShowDebugAsserts.AutoSize = true;
            this.chkShowDebugAsserts.Location = new System.Drawing.Point(116, 540);
            this.chkShowDebugAsserts.Name = "chkShowDebugAsserts";
            this.chkShowDebugAsserts.Size = new System.Drawing.Size(287, 23);
            this.chkShowDebugAsserts.TabIndex = 85;
            this.chkShowDebugAsserts.Text = "Show debugging asserts in UI";
            this.chkShowDebugAsserts.UseVisualStyleBackColor = true;
            this.chkShowDebugAsserts.CheckedChanged += new System.EventHandler(this.chkShowDebugAsserts_CheckedChanged);
            // 
            // btnGenerateCBApiSecret
            // 
            this.btnGenerateCBApiSecret.BackColor = System.Drawing.Color.OrangeRed;
            this.btnGenerateCBApiSecret.ForeColor = System.Drawing.Color.White;
            this.btnGenerateCBApiSecret.Location = new System.Drawing.Point(6, 103);
            this.btnGenerateCBApiSecret.Name = "btnGenerateCBApiSecret";
            this.btnGenerateCBApiSecret.Size = new System.Drawing.Size(328, 46);
            this.btnGenerateCBApiSecret.TabIndex = 86;
            this.btnGenerateCBApiSecret.Text = "Bootstrap to create user access tokens";
            this.btnGenerateCBApiSecret.UseVisualStyleBackColor = false;
            this.btnGenerateCBApiSecret.Click += new System.EventHandler(this.btnGenerateCBApiSecret_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 19);
            this.label1.TabIndex = 87;
            this.label1.Text = "User tokens secrets file";
            // 
            // txtPathToUserTokenSecrets
            // 
            this.txtPathToUserTokenSecrets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathToUserTokenSecrets.Location = new System.Drawing.Point(289, 40);
            this.txtPathToUserTokenSecrets.Name = "txtPathToUserTokenSecrets";
            this.txtPathToUserTokenSecrets.Size = new System.Drawing.Size(1139, 26);
            this.txtPathToUserTokenSecrets.TabIndex = 88;
            this.txtPathToUserTokenSecrets.Text = "<<Path to the secrets file...>>";
            // 
            // btnSaveUserAuthToken
            // 
            this.btnSaveUserAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUserAuthToken.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveUserAuthToken.ForeColor = System.Drawing.Color.White;
            this.btnSaveUserAuthToken.Location = new System.Drawing.Point(1088, 32);
            this.btnSaveUserAuthToken.Name = "btnSaveUserAuthToken";
            this.btnSaveUserAuthToken.Size = new System.Drawing.Size(328, 46);
            this.btnSaveUserAuthToken.TabIndex = 89;
            this.btnSaveUserAuthToken.Text = "Save the user access tokens to storage";
            this.btnSaveUserAuthToken.UseVisualStyleBackColor = false;
            this.btnSaveUserAuthToken.Click += new System.EventHandler(this.btnSaveUserAuthToken_Click);
            // 
            // btnLoadUserTokenFromFile
            // 
            this.btnLoadUserTokenFromFile.BackColor = System.Drawing.Color.OrangeRed;
            this.btnLoadUserTokenFromFile.ForeColor = System.Drawing.Color.White;
            this.btnLoadUserTokenFromFile.Location = new System.Drawing.Point(391, 103);
            this.btnLoadUserTokenFromFile.Name = "btnLoadUserTokenFromFile";
            this.btnLoadUserTokenFromFile.Size = new System.Drawing.Size(328, 46);
            this.btnLoadUserTokenFromFile.TabIndex = 90;
            this.btnLoadUserTokenFromFile.Text = "Load user access tokens from file";
            this.btnLoadUserTokenFromFile.UseVisualStyleBackColor = false;
            this.btnLoadUserTokenFromFile.Click += new System.EventHandler(this.btnLoadUserTokenFromFile_Click);
            // 
            // blnClearLogs
            // 
            this.blnClearLogs.Location = new System.Drawing.Point(431, 528);
            this.blnClearLogs.Name = "blnClearLogs";
            this.blnClearLogs.Size = new System.Drawing.Size(112, 34);
            this.blnClearLogs.TabIndex = 91;
            this.blnClearLogs.Text = "Clear Logs";
            this.blnClearLogs.UseVisualStyleBackColor = true;
            this.blnClearLogs.Click += new System.EventHandler(this.blnClearLogs_Click);
            // 
            // panelAuthSessionDetails
            // 
            this.panelAuthSessionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAuthSessionDetails.Controls.Add(this.btnForceRefreshOfUserTokens);
            this.panelAuthSessionDetails.Controls.Add(this.txtAuthSessionInfo);
            this.panelAuthSessionDetails.Controls.Add(this.label6);
            this.panelAuthSessionDetails.Controls.Add(this.btnSaveUserAuthToken);
            this.panelAuthSessionDetails.Location = new System.Drawing.Point(9, 168);
            this.panelAuthSessionDetails.Name = "panelAuthSessionDetails";
            this.panelAuthSessionDetails.Size = new System.Drawing.Size(1419, 143);
            this.panelAuthSessionDetails.TabIndex = 92;
            // 
            // btnForceRefreshOfUserTokens
            // 
            this.btnForceRefreshOfUserTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForceRefreshOfUserTokens.BackColor = System.Drawing.Color.SteelBlue;
            this.btnForceRefreshOfUserTokens.ForeColor = System.Drawing.Color.White;
            this.btnForceRefreshOfUserTokens.Location = new System.Drawing.Point(1091, 84);
            this.btnForceRefreshOfUserTokens.Name = "btnForceRefreshOfUserTokens";
            this.btnForceRefreshOfUserTokens.Size = new System.Drawing.Size(328, 46);
            this.btnForceRefreshOfUserTokens.TabIndex = 95;
            this.btnForceRefreshOfUserTokens.Text = "Force refresh/replacement of user access tokens";
            this.btnForceRefreshOfUserTokens.UseVisualStyleBackColor = false;
            this.btnForceRefreshOfUserTokens.Click += new System.EventHandler(this.btnForceRefreshOfUserTokens_Click);
            // 
            // txtAuthSessionInfo
            // 
            this.txtAuthSessionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthSessionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.txtAuthSessionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAuthSessionInfo.Location = new System.Drawing.Point(6, 32);
            this.txtAuthSessionInfo.Multiline = true;
            this.txtAuthSessionInfo.Name = "txtAuthSessionInfo";
            this.txtAuthSessionInfo.Size = new System.Drawing.Size(1076, 102);
            this.txtAuthSessionInfo.TabIndex = 94;
            this.txtAuthSessionInfo.Text = "status of auth tokens shown here...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(252, 19);
            this.label6.TabIndex = 93;
            this.label6.Text = "REST API Access tokens info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(347, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 19);
            this.label7.TabIndex = 93;
            this.label7.Text = "OR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(9, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(506, 28);
            this.label8.TabIndex = 94;
            this.label8.Text = "STEP 2: Choose REST API actions to run";
            // 
            // btnQueryHotelDashboard
            // 
            this.btnQueryHotelDashboard.BackColor = System.Drawing.Color.SeaGreen;
            this.btnQueryHotelDashboard.ForeColor = System.Drawing.Color.White;
            this.btnQueryHotelDashboard.Location = new System.Drawing.Point(15, 364);
            this.btnQueryHotelDashboard.Name = "btnQueryHotelDashboard";
            this.btnQueryHotelDashboard.Size = new System.Drawing.Size(328, 46);
            this.btnQueryHotelDashboard.TabIndex = 95;
            this.btnQueryHotelDashboard.Text = "Query hotel dashboard";
            this.btnQueryHotelDashboard.UseVisualStyleBackColor = false;
            this.btnQueryHotelDashboard.Click += new System.EventHandler(this.btnQueryHotelDashboard_Click);
            // 
            // btnQueryUserInfo
            // 
            this.btnQueryUserInfo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnQueryUserInfo.ForeColor = System.Drawing.Color.White;
            this.btnQueryUserInfo.Location = new System.Drawing.Point(391, 364);
            this.btnQueryUserInfo.Name = "btnQueryUserInfo";
            this.btnQueryUserInfo.Size = new System.Drawing.Size(328, 46);
            this.btnQueryUserInfo.TabIndex = 96;
            this.btnQueryUserInfo.Text = "Query user info";
            this.btnQueryUserInfo.UseVisualStyleBackColor = false;
            this.btnQueryUserInfo.Click += new System.EventHandler(this.btnQueryUserInfo_Click);
            // 
            // FormCBUtilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1433, 882);
            this.Controls.Add(this.btnQueryUserInfo);
            this.Controls.Add(this.btnQueryHotelDashboard);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelAuthSessionDetails);
            this.Controls.Add(this.blnClearLogs);
            this.Controls.Add(this.btnLoadUserTokenFromFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathToUserTokenSecrets);
            this.Controls.Add(this.btnGenerateCBApiSecret);
            this.Controls.Add(this.chkShowDebugAsserts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathToAppSecrets);
            this.Controls.Add(this.splitContainerStatus);
            this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FormCBUtilities";
            this.Text = "CB Utilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerStatus.Panel1.ResumeLayout(false);
            this.splitContainerStatus.Panel1.PerformLayout();
            this.splitContainerStatus.Panel2.ResumeLayout(false);
            this.splitContainerStatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).EndInit();
            this.splitContainerStatus.ResumeLayout(false);
            this.panelAuthSessionDetails.ResumeLayout(false);
            this.panelAuthSessionDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerStatus;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.CheckBox chkVerboseLog;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox txtPathToAppSecrets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkShowDebugAsserts;
        private System.Windows.Forms.Button btnGenerateCBApiSecret;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtPathToUserTokenSecrets;
    private System.Windows.Forms.Button btnSaveUserAuthToken;
    private System.Windows.Forms.Button btnLoadUserTokenFromFile;
    private System.Windows.Forms.Button blnClearLogs;
    private System.Windows.Forms.Panel panelAuthSessionDetails;
    private System.Windows.Forms.TextBox txtAuthSessionInfo;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button btnQueryHotelDashboard;
    private System.Windows.Forms.Button btnForceRefreshOfUserTokens;
    private System.Windows.Forms.Button btnQueryUserInfo;
}

