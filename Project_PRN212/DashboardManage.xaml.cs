using PRN212_Assignment.Models;
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

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for DashboardManage.xaml
    /// </summary>
    public partial class DashboardManage : Window
    {
        private User _loggedInUser;
        private Prn212AssignmentBookShoppingContext _context;
        public DashboardManage(User _loggedInUser)
        {
            InitializeComponent();
            _context = new Prn212AssignmentBookShoppingContext();
            LoadData();
        }

        private void LoadData()
        {
            int totalUsers = _context.Users.Count();
            TotalUsersTextBlock.Text = totalUsers.ToString();

            int totalBooks = _context.Books.Count();
            TotalBooksTextBlock.Text = totalBooks.ToString();

            int totalAuthors = _context.Authors.Count();
            TotalAuthorsTextBlock.Text = totalAuthors.ToString();

            decimal totalRevenue = (decimal)_context.Orders
                   .Join(_context.Books,
                       order => order.BookId,
                       book => book.BookId,
                       (order, book) => new
                       {
                           order.Quantity,
                           RevenuePerBook = book.PriceOutput - book.PriceInput
                       })
                   .Sum(orderBook => orderBook.Quantity * orderBook.RevenuePerBook);

            TotalRevenueTextBlock.Text = $"{totalRevenue:C}";
        }

        private void DashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardManage dashboardManage = new DashboardManage(_loggedInUser);
            dashboardManage.Show();
            this.Close();
        }

        private void UserListButton_Click(object sender, RoutedEventArgs e)
        {
            UserAuthorization userAuth = new UserAuthorization();
            userAuth.Show();
        }

        private void BookListButton_Click(object sender, RoutedEventArgs e)
        {
            BookList bookList = new BookList();
            bookList.Show();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
