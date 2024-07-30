using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : Window
    {
        private readonly Prn212AssignmentBookShoppingContext _context;

        public BookList()
        {
            InitializeComponent();
            _context = new Prn212AssignmentBookShoppingContext();
            LoadData();
        }

        private void LoadData()
        {
            var books = _context.Books.Select(b => new
            {
                BookID = b.BookId,
                BookName = b.BookName,
                Quantity = b.Quantity,
                PriceInput = b.PriceInput,
                PriceOutput = b.PriceOutput
            }).ToList();

            BooksListView.ItemsSource = books;
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredBooks = _context.Books
                .Where(b => b.BookName.ToLower().Contains(searchText))
                .Select(b => new
                {
                    BookID = b.BookId,
                    BookName = b.BookName,
                    Quantity = b.Quantity,
                    PriceInput = b.PriceInput,
                    PriceOutput = b.PriceOutput
                })
                .ToList();
            BooksListView.ItemsSource = filteredBooks;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
