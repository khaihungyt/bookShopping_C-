using PRN212_Assignment.Models;

using System.Windows;

namespace PRN212_Assignment
{
    public partial class EditGenreWindow : Window
    {
        private Genre _genre;

        public EditGenreWindow(Genre genre)
        {
            InitializeComponent();
            _genre = genre;
            txtEditGenreName.Text = _genre.GenreName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var genreToUpdate = context.Genres.FirstOrDefault(g => g.GenreId == _genre.GenreId);
                if (genreToUpdate != null)
                {
                    genreToUpdate.GenreName = txtEditGenreName.Text.Trim();
                    context.SaveChanges();
                }
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
