using PRN212_Assignment.Models;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PRN212_Assignment
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
            private readonly Prn212AssignmentBookShoppingContext context;
        private string _currentPage;
         private User _loggedInUser;

        public MainWindow(User loggedInUser)
        {
            InitializeComponent();
            DataContext = this;
            context = new Prn212AssignmentBookShoppingContext();
            CurrentPage = "Home"; // Set trang khởi đầu
            _loggedInUser = loggedInUser;
            loaddata();
        }
        private void loaddata()
        {
            var totalUser = context.Users.Count();
            var totalOrder = context.Orders.Count();
            var totalProduct = context.Books.Count();
            var totalComment = context.Comments.Count();
            var totalRevenue = (int)CalculateTotalRevenue();
            TotalUsersText.Text = totalUser.ToString();
            TotalOrdersText.Text = totalOrder.ToString();
            TotalProductsText.Text = totalProduct.ToString();
            TotalCommentText.Text = totalComment.ToString();
            TotalRevenueText.Text = totalRevenue.ToString();


        }
        private int CalculateTotalRevenue()
        {
            // Calculate the total revenue for completed orders
            var totalRevenue = context.Orders
                .Where(o => o.OrderStatus == "Completed")
                .Sum(o => (o.Quantity * (o.Book.PriceOutput - o.Book.PriceInput)));
            return (int)totalRevenue;
         
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }



        public string CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void ExportDataToFile()
        {
            var totalUsers = context.Users.Count();
            var totalOrders = context.Orders.Count();
            var totalProducts = context.Books.Count();
            var totalComments = context.Comments.Count();
            var totalRevenue = context.Orders
                .Where(o => o.OrderStatus == "Completed")
                .Sum(o => o.Quantity * (o.Book.PriceOutput - o.Book.PriceInput));

            var filePath = "totalData.txt";
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Total Users: " + totalUsers);
                writer.WriteLine("Total Orders: " + totalOrders);
                writer.WriteLine("Total Products: " + totalProducts);
                writer.WriteLine("Total Comments: " + totalComments);
                writer.WriteLine("Total Revenue: " + totalRevenue.ToString("C"));
            }

            MessageBox.Show("Data exported to file.txt");
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportDataToFile();
        }

        

    }
}
