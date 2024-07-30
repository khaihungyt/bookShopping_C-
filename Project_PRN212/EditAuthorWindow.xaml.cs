using PRN212_Assignment.Models;

using System.Linq;
using System.Windows;

namespace PRN212_Assignment
{
    public partial class EditAuthorWindow : Window
    {
        private Author _author;

        public EditAuthorWindow(Author author)
        {
            InitializeComponent();
            _author = author;
            txtAuthorName.Text = _author.AuthorName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Prn212AssignmentBookShoppingContext())
            {
                var authorToUpdate = context.Authors.FirstOrDefault(a => a.AuthorId == _author.AuthorId);
                if (authorToUpdate != null)
                {
                    authorToUpdate.AuthorName = txtAuthorName.Text.Trim();
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
