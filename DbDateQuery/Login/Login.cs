using System;
using Npgsql;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using DbDQ.Entity;

namespace DbDateQuery.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Login Form Closing Events
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginFormClosing() == false)
            {
                this.FormClosing -= Login_FormClosing;
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private MessageBoxTextForLoginClosing StringValuesForMessageBox()
        {
            var messageboxText = new MessageBoxTextForLoginClosing
            {
                MessageBox_Message = "Çıkış yapmak istediğinizden emin misiniz?",
                MessageBox_Title = "Çıkış Onayı"
            };

            return messageboxText;
        }

        private bool LoginFormClosing()
        {
            var messageBoxText = StringValuesForMessageBox();

            if (MessageBox.Show(
                messageBoxText.MessageBox_Message, messageBoxText.MessageBox_Title,
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)

                return false;
            else
                return true;
        }
        #endregion

        #region Login Events
        private void LoginButtonLogin_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrWhiteSpace(UsernameTextboxLogin.Text.Trim()) &&
                !string.IsNullOrWhiteSpace(PasswordTextboxLogin.Text.Trim()))

                CheckUserFromDatabase();
        }
        private void CheckUserFromDatabase()
        {
            LoginButtonLogin.Enabled = false;
            LoginSplashProgressBar.Enabled = true;
            LoginSplashProgressBar.Visible = true;

            #region EF
            using (var cntxt = new DbDQContext())
            {
                bool checkUsername = cntxt.Tablo1
                    .Any(w => w.KullaniciAdi == UsernameTextboxLogin.Text.Trim());

                if (checkUsername == true)
                {
                    string userPassword = cntxt.Tablo1
                        .Where(w => w.KullaniciAdi == UsernameTextboxLogin.Text.Trim())
                        .FirstOrDefault().Parola;
                    CheckPasswordFromDatabase(userPassword);
                }
                else
                {
                    UsernameLabel.ForeColor = Color.IndianRed;

                    WarningLabelLogin.Text = "Kullanıcı adınız yanlış!";

                    ChangeStatusOfElements(true);

                }
            }
            #endregion
        }

        private void CheckPasswordFromDatabase(string parola)
        {
            if (PasswordTextboxLogin.Text.Trim() == parola)
                FormEventsWhenCheckSuccessful();

            else
            {
                PasswordLabel.ForeColor = Color.IndianRed;

                WarningLabelLogin.Text = "Parolanız yanlış!";

                ChangeStatusOfElements(true);
            }
        }

        private void FormEventsWhenCheckSuccessful()
        {
            QueryDate.QueryDate queryDateForm = new QueryDate.QueryDate();

            if (Application.OpenForms.OfType<Form>().Any(a => a is QueryDate.QueryDate))
                Application.OpenForms.OfType<Form>().First(f => f is QueryDate.QueryDate).Activate();

            else
            {
                queryDateForm.Show();
                this.FormClosing -= Login_FormClosing;
                this.Close();
            }
        }
        #endregion

        private void ChangeStatusOfElements(bool status)
        {
            WarningLabelLogin.Visible = status;

            LoginButtonLogin.Visible = status;

            LoginSplashProgressBar.Enabled = !status;
            LoginSplashProgressBar.Visible = !status;
        }

        #region Customize Textbox -- Password /// Check Textbox Null Value /// WarningLabel
        private void CustomizePassword_TextChanged(object sender, EventArgs e)
        {
            {
                UsernameLabel.ForeColor = SystemColors.ControlText;
                PasswordLabel.ForeColor = SystemColors.ControlText;

                WarningLabelLogin.Visible = false;
            }

            {
                if (ShowPasswordCheckboxLogin.Checked == true)
                    PasswordTextboxLogin.PasswordChar = '\0';
                else
                    PasswordTextboxLogin.PasswordChar = '*';
            }

            {
                if (!string.IsNullOrWhiteSpace(UsernameTextboxLogin.Text) &&
                        !string.IsNullOrWhiteSpace(PasswordTextboxLogin.Text))

                    LoginButtonLogin.Enabled = true;
                else
                    LoginButtonLogin.Enabled = false;
            }

        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                e.SuppressKeyPress = true;
        }
        #endregion


    }
}

public class MessageBoxTextForLoginClosing
{
    public string MessageBox_Message { get; set; }
    public string MessageBox_Title { get; set; }
}