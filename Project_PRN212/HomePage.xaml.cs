using PRN212_Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        private GridViewColumnHeader _lastHeaderClicked = null;
        private ListSortDirection _lastDirection = ListSortDirection.Ascending;
        public HomePage()
        {
            InitializeComponent();
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                lvBookList.ItemsSource = context.Books.Select(e =>new{
                    BookImage=e.Image1,
                    BookId=e.BookId,
                    BookName= e.BookName,
                    AuthorName= e.Author.AuthorName.ToString(),
                    GenreName=e.Genre.GenreName,
                    Quantity = e.Quantity,
                    Price=e.PriceOutput
                }).ToList();
            }
            // Attach the click event handler to all GridViewColumnHeaders
            foreach (var column in ((GridView)lvBookList.View).Columns)
            {
                if (column.Header is GridViewColumnHeader header)
                {
                        header.Click += GridViewColumnHeader_Click;
                }
                else
                {
                    var gridViewColumnHeader = new GridViewColumnHeader() { Content = column.Header };
                    string headerName = gridViewColumnHeader.Content as string;
                    if (!headerName.Equals("Image"))
                    {
                        gridViewColumnHeader.Click += GridViewColumnHeader_Click;
                    }
                    column.Header = gridViewColumnHeader;
                }
            }
        }
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    // Determine sort direction
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        direction = _lastDirection == ListSortDirection.Ascending
                                    ? ListSortDirection.Descending
                                    : ListSortDirection.Ascending;
                    }

                    // Get the field to sort by
                    var sortBy = ((Binding)((GridViewColumn)headerClicked.Column).DisplayMemberBinding).Path.Path;

                    // Perform the sort
                    Sort(sortBy, direction);

                    // Update the last header and direction
                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(lvBookList.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }




        private void lvBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String a= lvBookList.SelectedItem.ToString();
            String[] bookFound = a.Split(new char[] { '[', '=', ',' });
           
            BookDetail bookDetail = new BookDetail(bookFound[3].Trim()); 
            this.Close();
            bookDetail.Show();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show(); 
            this.Close();
            //ShoppingCart cart = new ShoppingCart("USER001");
            //this.Close();
            //cart.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                String found=txtSearch.Text.Trim();
                lvBookList.ItemsSource = context.Books.Where(c=> c.BookName.Contains(found)).Select(e => new {
                    BookImage = e.Image1,
                    BookId = e.BookId,
                    BookName = e.BookName,
                    AuthorName = e.Author.AuthorName.ToString(),
                    GenreName = e.Genre.GenreName,
                    Quantity = e.Quantity,
                    Price = e.PriceOutput
                }).ToList();
            }
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show(); 
            this.Close();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close(); 
        }
    }
}
