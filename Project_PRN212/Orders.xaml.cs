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
using Microsoft.Win32;
using System.IO;

namespace PRN212_Assignment
{
    public partial class Orders : Window
    {
        private readonly Prn212AssignmentBookShoppingContext _context;
        private readonly User _loggedInUser;

        public Orders(User loggedInUser)
        {
            InitializeComponent();
            _context = new Prn212AssignmentBookShoppingContext();
            _loggedInUser = loggedInUser;

            SetUserName(_loggedInUser.FirstName, _loggedInUser.LastName);

            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _context.Orders
                .Where(order => order.UserId == _loggedInUser.UserId)
                .Select(order => new
                {
                    OrderId = order.OrderId,
                    BookName = order.Book.BookName,
                    Quantity = order.Quantity,
                    OrderStatus = order.OrderStatus
                })
                .ToList();

            OrdersListView.ItemsSource = orders;
        }

        private void SetUserName(string firstName, string lastName)
        {
            UserNameTextBlock.Text = $"{firstName} {lastName}";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExportToTXT_Click(object sender, RoutedEventArgs e)
        {
            // Open SaveFileDialog to choose where to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save Orders As Text File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    var orders = _context.Orders
                        .Where(order => order.UserId == _loggedInUser.UserId)
                        .Select(order => new
                        {
                            OrderId = order.OrderId,
                            BookName = order.Book.BookName,
                            Quantity = order.Quantity,
                            OrderStatus = order.OrderStatus
                        })
                        .ToList();

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var order in orders)
                        {
                            string line = $"{order.OrderId};{order.BookName};{order.Quantity};{order.OrderStatus}";
                            writer.WriteLine(line);
                        }
                    }
                    CustomMessageBox.Show("Data exported successfully.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"An error occurred while exporting data: {ex.Message}");
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            var filteredOrders = _context.Orders
                .Where(order => order.UserId == _loggedInUser.UserId &&
                                (order.Book.BookName.ToLower().Contains(searchText) ||
                                 order.OrderStatus.ToLower().Contains(searchText)))
                .Select(order => new
                {
                    OrderId = order.OrderId,
                    BookName = order.Book.BookName,
                    Quantity = order.Quantity,
                    OrderStatus = order.OrderStatus
                })
                .ToList();

            OrdersListView.ItemsSource = filteredOrders;
        }

        private void OrdersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (OrdersListView.SelectedItem != null)
            {
                
                var orders = OrdersListView.ItemsSource.Cast<dynamic>().ToList();

                var sortedOrders = orders.OrderBy(order => order.Quantity).ToList();

                OrdersListView.ItemsSource = sortedOrders;
            }
        }

    }
}
