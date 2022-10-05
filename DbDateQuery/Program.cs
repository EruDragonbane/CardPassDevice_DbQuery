using System;
using Npgsql;
using System.Windows.Forms;

namespace DbDateQuery
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        
        public static NpgsqlConnection npgsqlCon = new NpgsqlConnection(
            "Server = ServerIP; " +
            "Port = Port; " +
            "DataBase = DatabaseName; " +
            "Username = Username; " +
            "Password = Password");
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = new Login.Login();
            loginForm.Show();
            Application.Run();
        }
    }
}
