using PRN212_Assignment.Models;
using System.Windows;

namespace PRN212_Assignment
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (ValidateLoginFields(username, password))
            {
                AuthenticateUser(username, password);
            }
            else
            {
                CustomMessageBox.Show("Please enter both username and password.");
            }
        }

        private bool ValidateLoginFields(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private void AuthenticateUser(string username, string password)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Userpassword))
                {
                    HandleLoginSuccess(user);
                }
                else
                {
                    CustomMessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void HandleLoginSuccess(User user)
        {
            CustomMessageBox.Show($"Welcome, {user.FirstName} {user.LastName}!");

            switch (user.UserRole)
            {
                case "Admin":
                    MainWindow mainWindow = new MainWindow(user); 
                    mainWindow.Show(); 
                    break;
                case "Customer":
                    HomePageCustomer homePageCustomer = new HomePageCustomer(user);
                    homePageCustomer.Show();
                    break;
                case "Manager":
                    DashboardManage dashboardManage = new DashboardManage(user);
                    dashboardManage.Show();
                    break;
                default:
                    CustomMessageBox.Show("Unknown role. Please contact support.");
                    break;
            }

            this.Close();
        }

        private void NavigateToRegister(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }
    }

}
