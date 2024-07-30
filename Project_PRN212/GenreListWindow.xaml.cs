
using PRN212_Assignment.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PRN212_Assignment
{
    public partial class GenreListWindow : Window
    {
        public GenreListWindow()
        {
            InitializeComponent();
            LoadGenres();
        }

        private void LoadGenres()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var genres = context.Genres.ToList();
                lvGenres.ItemsSource = genres;
            }
        }

        private string GenerateNewGenreId()
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                var lastGenre = context.Genres
                                       .OrderByDescending(g => g.GenreId)
                                       .FirstOrDefault();

                if (lastGenre == null)
                {
                    return "GEN001";
                }

                string lastGenreId = lastGenre.GenreId;
                if (lastGenreId.StartsWith("GEN"))
                {
                    int lastNumber;
                    if (int.TryParse(lastGenreId.Substring(3), out lastNumber))
                    {
                        return $"GEN{(lastNumber + 1).ToString("D3")}";
                    }
                }

                // Fallback in case the lastGenreId format is unexpected
                return "GEN001";
            }
        }

        private void AddNewGenreButton_Click(object sender, RoutedEventArgs e)
        {
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                string genreName = txtGenreName.Text.Trim();
                if (!string.IsNullOrEmpty(genreName))
                {
                    var newGenre = new Genre
                    {
                        GenreId = GenerateNewGenreId(),
                        GenreName = genreName
                    };
                    context.Genres.Add(newGenre);
                    context.SaveChanges();
                    LoadGenres();
                    txtGenreName.Clear();
                }
                else
                {
                    MessageBox.Show("Genre Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var selectedGenre = button.DataContext as Genre;
                if (selectedGenre != null)
                {
                    EditGenreWindow editWindow = new EditGenreWindow(selectedGenre);
                    editWindow.ShowDialog();
                    LoadGenres(); // Reload the genre list to reflect changes
                }
                else
                {
                    MessageBox.Show("Selected genre is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var selectedGenre = button.DataContext as Genre;
                if (selectedGenre != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedGenre.GenreName}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
                        {
                            var genreToDelete = context.Genres.FirstOrDefault(g => g.GenreId == selectedGenre.GenreId);
                            if (genreToDelete != null)
                            {
                                context.Genres.Remove(genreToDelete);
                                context.SaveChanges();
                            }
                        }
                        LoadGenres(); // Reload the genre list to reflect changes
                    }
                }
                else
                {
                    MessageBox.Show("Selected genre is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
