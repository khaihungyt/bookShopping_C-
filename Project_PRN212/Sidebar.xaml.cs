using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    public partial class Sidebar : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _currentPage;
        private User _loggedInUser;

        public string CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                    UpdateButtonStates();
                }
            }
        }

        public Sidebar()
        {
            InitializeComponent();
            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UpdateButtonStates()
        {
            HomeButtonEnabled = CurrentPage != "Home";
            UsersButtonEnabled = CurrentPage != "Users";
            ProductsButtonEnabled = CurrentPage != "Products";
            OrdersButtonEnabled = CurrentPage != "Orders";
            GenresButtonEnabled = CurrentPage != "Genres";
            AuthorsButtonEnabled = CurrentPage != "Authors";

            HomeButtonBackground = CurrentPage == "Home" ? "#008B8B" : "#34495E";
            UsersButtonBackground = CurrentPage == "Users" ? "#008B8B" : "#34495E";
            ProductsButtonBackground = CurrentPage == "Products" ? "#008B8B" : "#34495E";
            OrdersButtonBackground = CurrentPage == "Orders" ? "#008B8B" : "#34495E";
            GenresButtonBackground = CurrentPage == "Genres" ? "#008B8B" : "#34495E";
            AuthorsButtonBackground = CurrentPage == "Authors" ? "#008B8B" : "#34495E";

            // Notify UI about changes
            OnPropertyChanged(nameof(HomeButtonEnabled));
            OnPropertyChanged(nameof(UsersButtonEnabled));
            OnPropertyChanged(nameof(ProductsButtonEnabled));
            OnPropertyChanged(nameof(OrdersButtonEnabled));
            OnPropertyChanged(nameof(GenresButtonEnabled));
            OnPropertyChanged(nameof(AuthorsButtonEnabled));
            OnPropertyChanged(nameof(HomeButtonBackground));
            OnPropertyChanged(nameof(UsersButtonBackground));
            OnPropertyChanged(nameof(ProductsButtonBackground));
            OnPropertyChanged(nameof(OrdersButtonBackground));
            OnPropertyChanged(nameof(GenresButtonBackground));
            OnPropertyChanged(nameof(AuthorsButtonBackground));
        }

        public bool HomeButtonEnabled { get; set; }
        public bool UsersButtonEnabled { get; set; }
        public bool ProductsButtonEnabled { get; set; }
        public bool OrdersButtonEnabled { get; set; }
        public bool GenresButtonEnabled { get; set; }
        public bool AuthorsButtonEnabled { get; set; }

        public string HomeButtonBackground { get; set; }
        public string UsersButtonBackground { get; set; }
        public string ProductsButtonBackground { get; set; }
        public string OrdersButtonBackground { get; set; }
        public string GenresButtonBackground { get; set; }
        public string AuthorsButtonBackground { get; set; }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInUser);
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productListWindow = new ProductListWindow(_loggedInUser);
            productListWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrderListWindow orderListWindow = new OrderListWindow();
            orderListWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void GenresButton_Click(object sender, RoutedEventArgs e)
        {
            GenreListWindow genreListWindow = new GenreListWindow();
            genreListWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorListWindow authorListWindow = new AuthorListWindow();
            authorListWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
