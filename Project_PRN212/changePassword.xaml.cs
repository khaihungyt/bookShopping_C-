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
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    public partial class changePassword : Window
    {
        private User _loggedInUser;

        public changePassword(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
        }

        private void UpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = CurrentPasswordBox.Password;
            string newPassword = NewPasswordBox.Password;
            string confirmNewPassword = ConfirmNewPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                CustomMessageBox.Show("All fields are required.");
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                CustomMessageBox.Show("New passwords do not match.");
                return;
            }

            // Regex to check if password has at least 6 characters
            if (!System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^.{6,}$"))
            {
                CustomMessageBox.Show("New password must be at least 6 characters long.");
                return;
            }

            if (!IsCurrentPasswordValid(currentPassword))
            {
                CustomMessageBox.Show("Current password is incorrect.");
                return;
            }

            UpdateUserPassword(newPassword);
            CustomMessageBox.Show("Password updated successfully.");
            this.Close();
        }

        private bool IsCurrentPasswordValid(string currentPassword)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == _loggedInUser.UserId);
                return user != null && BCrypt.Net.BCrypt.Verify(currentPassword, user.Userpassword);
            }
        }

        private void UpdateUserPassword(string newPassword)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == _loggedInUser.UserId);
                if (user != null)
                {
                    user.Userpassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    context.SaveChanges();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }

}
