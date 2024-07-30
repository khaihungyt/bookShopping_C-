using PRN212_Assignment.Models;

using System.Linq;
using System.Windows;

namespace PRN212_Assignment
{
    public partial class EditBookWindow : Window
    {
        private Book _book;

        public EditBookWindow(Book book)
        {
            InitializeComponent();
            _book = book;

            // Populate genres ComboBox
            PopulateGenresComboBox();

            // Populate authors ComboBox
            PopulateAuthorsComboBox();

            // Set existing book details
            tbBookName.Text = book.BookName;
            tbBookQuantity.Text = book.Quantity.ToString();
            tbBookPriceIn.Text = book.PriceInput.ToString();
            tbBookPriceOut.Text = book.PriceOutput.ToString();
            tbBookDetail.Text = book.Detailbook;

            // Select current genre and author in ComboBoxes
            cmbGenre.SelectedValue = book.GenreId;
            cmbAuthor.SelectedValue = book.AuthorId;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var bookToUpdate = context.Books.FirstOrDefault(b => b.BookId == _book.BookId);
                if (bookToUpdate != null)
                {
                    bookToUpdate.BookName = tbBookName.Text;
                    bookToUpdate.Quantity = int.Parse(tbBookQuantity.Text);
                    bookToUpdate.PriceInput = double.Parse(tbBookPriceIn.Text);
                    bookToUpdate.PriceOutput = double.Parse(tbBookPriceOut.Text);
                    bookToUpdate.GenreId = cmbGenre.SelectedValue.ToString(); // Update genre
                    bookToUpdate.AuthorId = cmbAuthor.SelectedValue.ToString(); // Update author
                    bookToUpdate.Detailbook = tbBookDetail.Text;

                    context.SaveChanges();
                }
            }
            this.Close();
        }
    }
}
