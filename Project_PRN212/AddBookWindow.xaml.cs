using PRN212_Assignment.Models;

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PRN212_Assignment
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();

            // Populate genres ComboBox
            PopulateGenresComboBox();

            // Populate authors ComboBox
            PopulateAuthorsComboBox();
        }

        private void PopulateGenresComboBox()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var genres = context.Genres.ToList();
                cmbGenre.ItemsSource = genres;
            }
        }

        private void PopulateAuthorsComboBox()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var authors = context.Authors.ToList();
                cmbAuthor.ItemsSource = authors;
            }
        }

        private string GenerateNewBookId()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var lastBook = context.Books
                                      .OrderByDescending(b => b.BookId)
                                      .FirstOrDefault();

                if (lastBook == null)
                {
                    return "B001";
                }

                string lastBookId = lastBook.BookId;
                if (lastBookId.StartsWith("B"))
                {
                    int lastNumber;
                    if (int.TryParse(lastBookId.Substring(1), out lastNumber))
                    {
                        return $"B{(lastNumber + 1).ToString("D3")}";
                    }
                }

                // Fallback in case the lastBookId format is unexpected
                return "B001";
            }
        }

        private void AddNewBookButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                string bookName = txtBookName.Text.Trim();
                string genreId = (cmbGenre.SelectedItem as Genre)?.GenreId;
                string authorId = (cmbAuthor.SelectedItem as Author)?.AuthorId;
                int quantity;
                double priceInput, priceOutput;

                if (!string.IsNullOrEmpty(bookName) &&
                    !string.IsNullOrEmpty(genreId) &&
                    !string.IsNullOrEmpty(authorId) &&
                    int.TryParse(txtQuantity.Text, out quantity) &&
                    double.TryParse(txtPriceInput.Text, out priceInput) &&
                    double.TryParse(txtPriceOutput.Text, out priceOutput))
                {
                    var newBook = new Book
                    {
                        BookId = GenerateNewBookId(),
                        BookName = bookName,
                        GenreId = genreId,
                        AuthorId = authorId,
                        Quantity = quantity,
                        PriceInput = priceInput,
                        PriceOutput = priceOutput,
                        Image1 = txtImage1.Text.Trim(),
                        Image2 = txtImage2.Text.Trim(),
                        Image3 = txtImage3.Text.Trim(),
                        Image4 = txtImage4.Text.Trim(),
                        Detailbook = txtDetailbook.Text.Trim()
                    };
                    context.Books.Add(newBook);
                    context.SaveChanges();
                    MessageBox.Show("Book added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
