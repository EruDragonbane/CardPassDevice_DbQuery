namespace DbDateQuery.Login
{
    partial class Login
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ShowPasswordCheckboxLogin = new System.Windows.Forms.CheckBox();
            this.LoginButtonLogin = new System.Windows.Forms.Button();
            this.WarningLabelLogin = new System.Windows.Forms.Label();
            this.PasswordTextboxLogin = new DbDateQuery.WatermarkTextbox.WatermarkTextbox();
            this.UsernameTextboxLogin = new DbDateQuery.WatermarkTextbox.WatermarkTextbox();
            this.LoginSplashProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UsernameLabel.Location = new System.Drawing.Point(60, 30);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(90, 18);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Kullanıcı Adı:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PasswordLabel.Location = new System.Drawing.Point(60, 90);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(55, 18);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Parola:";
            // 
            // ShowPasswordCheckboxLogin
            // 
            this.ShowPasswordCheckboxLogin.AutoSize = true;
            this.ShowPasswordCheckboxLogin.Location = new System.Drawing.Point(60, 145);
            this.ShowPasswordCheckboxLogin.Name = "ShowPasswordCheckboxLogin";
            this.ShowPasswordCheckboxLogin.Size = new System.Drawing.Size(128, 21);
            this.ShowPasswordCheckboxLogin.TabIndex = 4;
            this.ShowPasswordCheckboxLogin.Text = "Parolayı Göster";
            this.ShowPasswordCheckboxLogin.UseVisualStyleBackColor = true;
            this.ShowPasswordCheckboxLogin.TextChanged += new System.EventHandler(this.CustomizePassword_TextChanged);
            // 
            // LoginButtonLogin
            // 
            this.LoginButtonLogin.Enabled = false;
            this.LoginButtonLogin.Location = new System.Drawing.Point(60, 180);
            this.LoginButtonLogin.Name = "LoginButtonLogin";
            this.LoginButtonLogin.Size = new System.Drawing.Size(230, 27);
            this.LoginButtonLogin.TabIndex = 5;
            this.LoginButtonLogin.Text = "Giriş";
            this.LoginButtonLogin.UseVisualStyleBackColor = true;
            this.LoginButtonLogin.Click += new System.EventHandler(this.LoginButtonLogin_Click);
            // 
            // WarningLabelLogin
            // 
            this.WarningLabelLogin.AutoSize = true;
            this.WarningLabelLogin.ForeColor = System.Drawing.Color.IndianRed;
            this.WarningLabelLogin.Location = new System.Drawing.Point(60, 220);
            this.WarningLabelLogin.Name = "WarningLabelLogin";
            this.WarningLabelLogin.Size = new System.Drawing.Size(185, 17);
            this.WarningLabelLogin.TabIndex = 6;
            this.WarningLabelLogin.Text = "Uyarı: Kullanıcı adınız yanlış!";
            this.WarningLabelLogin.Visible = false;
            // 
            // PasswordTextboxLogin
            // 
            this.PasswordTextboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PasswordTextboxLogin.ForeColor = System.Drawing.Color.Black;
            this.PasswordTextboxLogin.Location = new System.Drawing.Point(60, 115);
            this.PasswordTextboxLogin.MaxLength = 50;
            this.PasswordTextboxLogin.Multiline = true;
            this.PasswordTextboxLogin.Name = "PasswordTextboxLogin";
            this.PasswordTextboxLogin.Size = new System.Drawing.Size(230, 27);
            this.PasswordTextboxLogin.TabIndex = 3;
            this.PasswordTextboxLogin.WatermarkText = "Parola";
            this.PasswordTextboxLogin.WatermarkTextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PasswordTextboxLogin.WordWrap = false;
            this.PasswordTextboxLogin.TextChanged += new System.EventHandler(this.CustomizePassword_TextChanged);
            this.PasswordTextboxLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_KeyDown);
            // 
            // UsernameTextboxLogin
            // 
            this.UsernameTextboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UsernameTextboxLogin.ForeColor = System.Drawing.Color.Black;
            this.UsernameTextboxLogin.Location = new System.Drawing.Point(60, 55);
            this.UsernameTextboxLogin.MaxLength = 50;
            this.UsernameTextboxLogin.Multiline = true;
            this.UsernameTextboxLogin.Name = "UsernameTextboxLogin";
            this.UsernameTextboxLogin.Size = new System.Drawing.Size(230, 27);
            this.UsernameTextboxLogin.TabIndex = 1;
            this.UsernameTextboxLogin.WatermarkText = "Kullanıcı Adı";
            this.UsernameTextboxLogin.WatermarkTextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.UsernameTextboxLogin.WordWrap = false;
            this.UsernameTextboxLogin.TextChanged += new System.EventHandler(this.CustomizePassword_TextChanged);
            this.UsernameTextboxLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_KeyDown);
            // 
            // LoginSplashProgressBar
            // 
            this.LoginSplashProgressBar.Enabled = false;
            this.LoginSplashProgressBar.Location = new System.Drawing.Point(15, 250);
            this.LoginSplashProgressBar.MarqueeAnimationSpeed = 30;
            this.LoginSplashProgressBar.Name = "LoginSplashProgressBar";
            this.LoginSplashProgressBar.Size = new System.Drawing.Size(320, 15);
            this.LoginSplashProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoginSplashProgressBar.TabIndex = 7;
            this.LoginSplashProgressBar.Visible = false;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginButtonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 283);
            this.Controls.Add(this.LoginSplashProgressBar);
            this.Controls.Add(this.WarningLabelLogin);
            this.Controls.Add(this.LoginButtonLogin);
            this.Controls.Add(this.ShowPasswordCheckboxLogin);
            this.Controls.Add(this.PasswordTextboxLogin);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameTextboxLogin);
            this.Controls.Add(this.UsernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private WatermarkTextbox.WatermarkTextbox UsernameTextboxLogin;
        private System.Windows.Forms.Label PasswordLabel;
        private WatermarkTextbox.WatermarkTextbox PasswordTextboxLogin;
        private System.Windows.Forms.CheckBox ShowPasswordCheckboxLogin;
        private System.Windows.Forms.Button LoginButtonLogin;
        private System.Windows.Forms.Label WarningLabelLogin;
        private System.Windows.Forms.ProgressBar LoginSplashProgressBar;
    }
}