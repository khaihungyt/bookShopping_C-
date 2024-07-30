using Microsoft.EntityFrameworkCore;
using PRN212_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace PRN212_Assignment
{
    public partial class UserAuthorization : Window
    {
        private Prn212AssignmentBookShoppingContext context;
        public UserAuthorization()
        {
            InitializeComponent();
            context = new Prn212AssignmentBookShoppingContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var roles = new List<string> { "Admin", "Customer" };

            var users = context.Users
                .Where(user => user.UserRole != "Manager")
                .Select(user => new 
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.UserRole,
                    Email = user.UserEmail,
                    AvailableRoles = roles
                })
                .ToList();

            UserListView.ItemsSource = users;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = new List<string> { "Admin", "Customer" };
            string searchTerm = SearchUserTextBox.Text.Trim();

            var filteredUsers = context.Users
                .Where(user => user.UserRole != "Manager" && user.Username.Contains(searchTerm))
                .Select(user => new
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.UserRole,
                    Email = user.UserEmail,
                    AvailableRoles = roles
                })
                .ToList();

            UserListView.ItemsSource = filteredUsers;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var user = button.DataContext as User;
            if (user == null) return;

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete user {user.Username}?", "Confirm Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                context.Users.Remove(user);
                context.SaveChanges();

                LoadUsers();
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null) return;

            string selectedUser = (string) comboBox.DataContext.GetType().GetProperty("UserId").GetValue(comboBox.DataContext, null);
            if (selectedUser == null) return;

            var selectedRole = comboBox.SelectedItem?.ToString();

            if (selectedRole != null)
            {
                var result = ConfirmRoleChange(selectedRole);

                if (result)
                {
                    UpdateUserRole(selectedUser, selectedRole);
                }
                else
                {
                    // Revert to previous selection if role change is canceled
                    var previousRole = e.RemovedItems.Count > 0 ? e.RemovedItems[0]?.ToString() : null;
                    comboBox.SelectedItem = previousRole;
                }
            }
        }

        private bool ConfirmRoleChange(string newRole)
        {
            var result = MessageBox.Show(
                $"Are you sure you want to change the role to {newRole}?",
                "Confirm Role Change",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }

        private void UpdateUserRole(string selectedUser, string newRole)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var user = context.Users.Find(selectedUser);
                if (user != null)
                {
                    user.UserRole = newRole;
                    context.SaveChanges();
                    MessageBox.Show("User role updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
