using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PRN212_Assignment.Models;



namespace PRN212_Assignment
{
    public partial class AuthorListWindow : Window
    {
        public AuthorListWindow()
        {
            InitializeComponent();
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var authors = context.Authors.ToList();
                lvAuthors.ItemsSource = authors;
            }
        }

        private void AddNewAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            string newAuthorId = GenerateNewAuthorId();
            string authorName = txtAuthorName.Text;

            if (!string.IsNullOrWhiteSpace(authorName))
            {
                using (var context = new Prn212AssignmentBookShoppingContext())
                {
                    var newAuthor = new Author
                    {
                        AuthorId = newAuthorId,
                        AuthorName = authorName
                    };

                    context.Authors.Add(newAuthor);
                    context.SaveChanges();
                }

                LoadAuthors(); // Refresh the list
                txtAuthorName.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter a valid author name.");
            }
        }

        private string GenerateNewAuthorId()
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var lastAuthor = context.Authors.OrderByDescending(a => a.AuthorId).FirstOrDefault();
                if (lastAuthor != null)
                {
                    string lastId = lastAuthor.AuthorId;
                    string numericPart = lastId.Substring(3); // Extract numeric part
                    if (int.TryParse(numericPart, out int number))
                    {
                        string newId = $"AUT{number + 1:D3}";
                        return newId;
                    }
                }
            }

            return "AUT001"; // Default if no authors exist
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var author = button.DataContext as Author;
                if (author != null)
                {
                    // Open edit window
                    var editWindow = new EditAuthorWindow(author);
                    editWindow.ShowDialog();

                    // Refresh the author list after editing
                    LoadAuthors();
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var author = button.DataContext as Author;
                if (author != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {author.AuthorName}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (var context = new Prn212AssignmentBookShoppingContext())
                        {
                            var authorToDelete = context.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
                            if (authorToDelete != null)
                            {
                                context.Authors.Remove(authorToDelete);
                                context.SaveChanges();
                            }
                        }

                        LoadAuthors(); // Refresh the list
                    }
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logout logic
        }
    }
}
