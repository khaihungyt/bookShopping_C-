using PRN212_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace PRN212_Assignment
{
    public partial class OrderListWindow : Window
    {
        private readonly Prn212AssignmentBookShoppingContext context;
        private readonly List<string> statuses = new List<string> { "Processing", "Delivering", "Completed", "Cancelled" };

        public OrderListWindow()
        {
            InitializeComponent();
            context = new Prn212AssignmentBookShoppingContext();
            LoadData();
            Sidebar sidebar = (Sidebar)this.FindName("SidebarControl");
            if (sidebar != null)
            {
                sidebar.CurrentPage = "Orders";
            }
            cbStatus.ItemsSource = statuses; // Set the statuses to the ComboBox
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var sortCriterion = selectedItem.Content.ToString();

                var sortedOrders = context.Orders
                    .Select(o => new
                    {
                        OrderId = o.OrderId,
                        Username = o.User.Username,
                        BookName = o.Book.BookName,
                        Image1 = o.Book.Image1,
                        Quantity = o.Quantity,
                        TotalCost = (o.Book.PriceOutput * o.Quantity).ToString(),
                        OrderStatus = o.OrderStatus,
                    });

                switch (sortCriterion)
                {
                    case "Sort by Order ID":
                        sortedOrders = sortedOrders.OrderBy(o => o.OrderId);
                        break;
                    case "Sort by Customer Name":
                        sortedOrders = sortedOrders.OrderBy(o => o.Username);
                        break;
                    case "Sort by Order Status":
                        sortedOrders = sortedOrders.OrderBy(o => o.OrderStatus);
                        break;
                }

                OrdersListView.ItemsSource = sortedOrders.ToList();
            }
        }

        private void LoadData()
        {
            var orders = context.Orders.Select(e => new
            {
                OrderId = e.OrderId,
                Username = e.User.Username,
                BookName = e.Book.BookName,
                Image1 = e.Book.Image1,
                Quantity = e.Quantity,
                OrderStatus = e.OrderStatus,
                TotalCost = (e.Book.PriceOutput * e.Quantity).ToString(),
            }).ToList();

            OrdersListView.ItemsSource = orders;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var orderId = txtId.Text.Trim();
            var newStatus = cbStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Please enter a valid Order ID and select a new status.");
                return;
            }

            var existingOrder = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder != null)
            {
                if (IsStatusChangeValid(existingOrder.OrderStatus, newStatus))
                {
                    existingOrder.OrderStatus = newStatus;

                    if (newStatus == "Delivering")
                    {
                        var book = context.Books.FirstOrDefault(b => b.BookId == existingOrder.BookId);
                        if (book != null)
                        {
                            book.Quantity -= existingOrder.Quantity;
                        }
                    }

                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Order {existingOrder.OrderId} status has been updated to {newStatus}.");
                }
                else
                {
                    MessageBox.Show("Invalid status change.");
                }
            }
            else
            {
                MessageBox.Show("Order not found.");
            }
        }

        private bool IsStatusChangeValid(string currentStatus, string newStatus)
        {
            var validTransitions = new Dictionary<string, HashSet<string>>
            {
                { "Processing", new HashSet<string> { "Delivering", "Cancelled" } },
                { "Delivering", new HashSet<string> { "Completed", "Cancelled" } },
                { "Completed", new HashSet<string>() },
                { "Cancelled", new HashSet<string>() }
            };

            return validTransitions.ContainsKey(currentStatus) && validTransitions[currentStatus].Contains(newStatus);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void OrdersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersListView.SelectedItem is Order selectedOrder)
            {
                txtId.Text = selectedOrder.OrderId;
                cbStatus.SelectedItem = selectedOrder.OrderStatus;
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Define the file path (you can use a SaveFileDialog for a better user experience)
                string filePath = "OrdersExport.txt";

                // Prepare the data for export
                var exportData = new StringBuilder();
                exportData.AppendLine("OrderID\tCustomerName\tBookName\tQuantity\tTotalCost\tOrderStatus");

                foreach (var item in OrdersListView.Items)
                {
                    // Assuming `item` is of type dynamic based on previous example
                    var order = item as dynamic;
                    exportData.AppendLine($"{order.OrderId}\t{order.Username}\t{order.BookName}\t{order.Quantity}\t{order.TotalCost}\t{order.OrderStatus}");
                }

                // Write the data to a file
                File.WriteAllText(filePath, exportData.ToString());

                MessageBox.Show($"Data has been exported to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting data: {ex.Message}");
            }
        }
    }
}
