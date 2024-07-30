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
using PRN212_Assignment;

namespace PRN212_Assignment
{
    public partial class userProfile : Window
    {
        private User _loggedInUser;

        public userProfile(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            LoadUserData();
        }

        private void LoadUserData()
        {
            FirstNameTextBox.Text = _loggedInUser.FirstName;
            LastNameTextBox.Text = _loggedInUser.LastName;
            UsernameTextBlock.Text = _loggedInUser.Username;
            EmailTextBlock.Text = _loggedInUser.UserEmail;
            AddressTextBox.Text = _loggedInUser.UserAddress;
            RoleTextBlock.Text = _loggedInUser.UserRole;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser.FirstName = FirstNameTextBox.Text;
            _loggedInUser.LastName = LastNameTextBox.Text;
            _loggedInUser.UserAddress = AddressTextBox.Text;
            SaveUserData(_loggedInUser);
        }

        private void SaveUserData(User user)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var existingUser = context.Users.SingleOrDefault(u => u.UserId == user.UserId);

                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.UserAddress = user.UserAddress;

                    context.SaveChanges();
                    CustomMessageBox.Show("User data updated successfully.");
                }
                else
                {
                    CustomMessageBox.Show("User not found.");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadUserData();
        }

        private void MyOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders ordersWindow = new Orders(_loggedInUser);
            ordersWindow.Show();
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            changePassword changePasswordWindow = new changePassword(_loggedInUser);
            changePasswordWindow.Show();
        }

        private void BackToHomepage_Click(object sender, RoutedEventArgs e)
        {
            HomePageCustomer homePageWindow = new HomePageCustomer(_loggedInUser);
            homePageWindow.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }

}
