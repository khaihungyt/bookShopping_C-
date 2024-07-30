using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PRN212_Assignment.Models;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PRN212_Assignment
{
    public partial class ProductListWindow : Window, INotifyPropertyChanged
    {
        private string _currentPage;
        
        private User _loggedInUser;

        public ProductListWindow(User loggedInUser)
        {
            InitializeComponent();
            DataContext = this;
            CurrentPage = "Products"; // Set initial page
            _loggedInUser = loggedInUser;

            LoadBook();
        }

        public void LoadBook()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var books = context.Books.ToList();
                lvBooks.ItemsSource = books.Select(e => new
                {
                    Book = e, // Include the Book object
                    e.BookId,
                    e.BookName,
                    e.Quantity,
                    e.Image1,
                    e.PriceInput,
                    e.PriceOutput,
                    AuthorName = context.Authors.FirstOrDefault(a => a.AuthorId == e.AuthorId)?.AuthorName,
                    GenreName = context.Genres.FirstOrDefault(g => g.GenreId == e.GenreId)?.GenreName
                }).ToList();
            }
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

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            //{
            //    if (cmbSort.SelectedItem is ComboBoxItem selectedItem)
            //    {
            //        // Get the selected sort criteria
            //        var sortCriterion = selectedItem.Content.ToString();

            //        // Perform sorting based on the selected criterion
            //        var sortedBooks = context.Books
            //            .Select(o => new
            //            {
            //                BookId = o.BookId,
            //                BookName = o.BookName,
            //                Quantity = o.Quantity,
            //                PriceInput=o.PriceInput,
            //                PriceOutput=  o.PriceOutput,
            //                AuthorName = o.Author.AuthorName ,
            //                GenreName = o.Genre.GenreName ,

            //                Image1 = o.Image1,
                           

                           
            //            });

            //        // Apply sorting based on the selected criterion
            //        switch (sortCriterion)
            //        {
            //            case "Name A-Z":
            //                sortedBooks = sortedBooks.OrderBy(o => o.BookName);
            //                break;
            //            case "Name Z-A":
            //                sortedBooks = sortedBooks.OrderByDescending(o => o.BookName);
            //                break;
                      
                            
            //        }

            //        // Update the DataGrid with sorted data
            //        lvBooks.ItemsSource = sortedBooks.ToList();
            //    }
            //}
        }



        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = ((FrameworkElement)sender).DataContext;
            ProductDetailWindow detailWindow = new ProductDetailWindow(selectedBook);
            detailWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var selectedBook = button.DataContext as dynamic;
                if (selectedBook != null)
                {
                    Book book = selectedBook.Book;
                    EditBookWindow editWindow = new EditBookWindow(book);
                    editWindow.ShowDialog();
                    LoadBook(); // Reload the book list to reflect changes
                }
                else
                {
                    MessageBox.Show("Selected book is null.");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var selectedBook = button.DataContext as dynamic; // Use dynamic to access anonymous type properties
                if (selectedBook != null)
                {
                    Book book = selectedBook.Book; // Access the Book object
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {book.BookName}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
                        {
                            var bookToDelete = context.Books.FirstOrDefault(b => b.BookId == book.BookId);
                            if (bookToDelete != null)
                            {
                                context.Books.Remove(bookToDelete);
                                context.SaveChanges();
                            }
                        }
                        LoadBook(); // Reload the book list to reflect changes
                    }
                }
                else
                {
                    MessageBox.Show("Selected book is null.");
                }
            }
        }

        private void AddNewBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.ShowDialog();
            LoadBook(); // Reload the book list to reflect the new book
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = ".json";
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    var jsonOptions = new JsonSerializerOptions
                    {
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                    };

                    string jsonContent = File.ReadAllText(openFileDialog.FileName);
                    List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonContent, jsonOptions);

                    // Đảm bảo dữ liệu liên kết đến Author và Genre được khôi phục đúng cách
                    foreach (var book in books)
                    {
                        book.Author = context.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
                        book.Genre = context.Genres.FirstOrDefault(g => g.GenreId == book.GenreId);
                    }

                    lvBooks.ItemsSource = books;
                    MessageBox.Show("Import thành công");
                }
            }
        }



        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                // Lấy danh sách sách từ cơ sở dữ liệu
                List<Book> bookList = context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

                // Mở hộp thoại lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".json";
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    var jsonOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                    };

                    // Chuyển đổi danh sách sách thành JSON
                    string jsonContent = JsonSerializer.Serialize(bookList, jsonOptions);

                    // Ghi JSON vào file
                    File.WriteAllText(saveFileDialog.FileName, jsonContent);
                    MessageBox.Show("Export thành công");
                }
            }
        }


    }
}
