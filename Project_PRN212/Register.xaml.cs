using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using PRN212_Assignment.Models;



namespace PRN212_Assignment
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string email = EmailTextBox.Text;
            string address = AddressTextBox.Text;

            if (!ValidateRegistration(email, username, password, confirmPassword))
            {
                return;
            }

            RegisterUsers(firstName, lastName, username, password, email, address);
        }

        private bool ValidateRegistration(string email, string username, string password, string confirmPassword)
        {
            // Regex pattern for validating email addresses
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Regex pattern for validating username to ensure it contains both letters and numbers
            string usernamePattern = @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]+$";

            // Regex pattern for validating password to ensure it is at least 6 characters long
            string passwordPattern = @"^.{6,}$";

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, emailPattern))
            {
                ShowError("Invalid email address.");
                return false;
            }

            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, usernamePattern))
            {
                ShowError("Username must contain both letters and numbers.");
                return false;
            }

            if (string.IsNullOrEmpty(password) || !Regex.IsMatch(password, passwordPattern))
            {
                ShowError("Password must be at least 6 characters long.");
                return false;
            }

            if (password != confirmPassword)
            {
                ShowError("Passwords do not match.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            CustomMessageBox.Show(message);
        }

        private void RegisterUsers(string firstName, string lastName, string username, string password, string email, string address)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                string newUserId = GenerateNewUserId(context);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                var user = new User
                {
                    UserId = newUserId,
                    FirstName = firstName,
                    LastName = lastName,
                    Username = username,
                    Userpassword = hashedPassword,
                    UserEmail = email,
                    UserRole = "Customer",
                    UserAddress = address
                };

                context.Users.Add(user);
                context.SaveChanges();

                ShowRegistrationSuccessMessageAndNavigate($"User {username} registered successfully. You will be redirected to the login page.");
            }
        }

        private void ShowRegistrationSuccessMessageAndNavigate(string message)
        {
            CustomMessageBox messageBox = new CustomMessageBox(message);

            messageBox.Closed += (s, e) =>
            {
                var loginWindow = new Login();
                loginWindow.Show();
                this.Close();
            };

            messageBox.ShowDialog();
        }

        private string GenerateNewUserId(Prn212AssignmentBookShoppingContext context)
        {
            var highestUserId = context.Users
                .OrderByDescending(u => u.UserId)
                .Select(u => u.UserId)
                .FirstOrDefault();

            string newUserId = "USER001";

            if (highestUserId != null)
            {
                int sequenceNumber;
                if (int.TryParse(highestUserId.Substring(4), out sequenceNumber))
                {
                    sequenceNumber++;
                    newUserId = "USER" + sequenceNumber.ToString("D3");
                }
            }

            while (context.Users.Any(u => u.UserId == newUserId))
            {
                int sequenceNumber = int.Parse(newUserId.Substring(4)) + 1;
                newUserId = "USER" + sequenceNumber.ToString("D3");
            }

            return newUserId;
        }

        private void NavigateToLogin(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
