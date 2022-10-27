partial class FormGetOauthResponse
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
            this.textBoxAuthRequestUri = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReponseUrlFromBrowser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxAuthRequestUri
            // 
            this.textBoxAuthRequestUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAuthRequestUri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxAuthRequestUri.Location = new System.Drawing.Point(9, 54);
            this.textBoxAuthRequestUri.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBoxAuthRequestUri.Multiline = true;
            this.textBoxAuthRequestUri.Name = "textBoxAuthRequestUri";
            this.textBoxAuthRequestUri.ReadOnly = true;
            this.textBoxAuthRequestUri.Size = new System.Drawing.Size(957, 148);
            this.textBoxAuthRequestUri.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(545, 561);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(421, 69);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step 1: Copy/paste this URL into your internet browser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step 2: Agree to the Cloudbeds access request";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 321);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(744, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Step 3: Copy/Paste the response URL into the textbox";
            // 
            // txtReponseUrlFromBrowser
            // 
            this.txtReponseUrlFromBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReponseUrlFromBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtReponseUrlFromBrowser.Location = new System.Drawing.Point(9, 369);
            this.txtReponseUrlFromBrowser.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtReponseUrlFromBrowser.Multiline = true;
            this.txtReponseUrlFromBrowser.Name = "txtReponseUrlFromBrowser";
            this.txtReponseUrlFromBrowser.Size = new System.Drawing.Size(957, 160);
            this.txtReponseUrlFromBrowser.TabIndex = 5;
            // 
            // FormGetOauthResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.txtReponseUrlFromBrowser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxAuthRequestUri);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FormGetOauthResponse";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormGetOauthResponse";
            this.Load += new System.EventHandler(this.FormGetOauthResponse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxAuthRequestUri;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtReponseUrlFromBrowser;
}