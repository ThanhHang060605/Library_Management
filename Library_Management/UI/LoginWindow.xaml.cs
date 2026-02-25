using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Library_Management.Models;

namespace Library_Management.UI
{
    public partial class LoginWindow : Window
    {
        private List<Account> accounts;

        public LoginWindow()
        {
            InitializeComponent();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            accounts = new List<Account>
            {
                new Account { Username = "admin", Password = "12345", Role = "Admin" },
                new Account { Username = "user", Password = "12345", Role = "User" }
            };
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var account = accounts
                .FirstOrDefault(a => a.Username == username && a.Password == password);

            if (account != null)
            {
                MessageBox.Show("Login successful!");

                MainWindow main = new MainWindow(account.Role);
                main.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
    }
}