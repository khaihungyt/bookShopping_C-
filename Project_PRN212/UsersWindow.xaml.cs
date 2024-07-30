using PRN212_Assignment.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace PRN212_Assignment
{
    public partial class UsersWindow : Window, INotifyPropertyChanged
    {
        private string _currentPage;
        private readonly Prn212AssignmentBookShoppingContext context;

        public UsersWindow()
        {
            InitializeComponent();
            DataContext = this;
            context = new Prn212AssignmentBookShoppingContext();
            CurrentPage = "Users";
            LoadData();
        }

        private void LoadData()
        {
            CommentDataGrid.ItemsSource = context.Comments.Select(e => new
            {
                CommentId = e.CommentId,
                Username = e.User.Username,
                BookName = e.Book.BookName,
                Comment1 = e.Comment1,
            }).ToList();
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

        //private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
        //    {
        //        var sortCriterion = selectedItem.Tag.ToString();

        //        var sortedComments = context.Comments.Select(c => new
        //        {
        //            CommentId = c.CommentId,
        //            Username = c.User.Username,
        //            BookName = c.Book.BookName,
        //            Comment1 = c.Comment1,
        //        }).ToList();

        //        switch (sortCriterion)
        //        {
        //            case "CommentId":
        //                sortedComments = sortedComments.OrderBy(c => c.CommentId);
        //                break;
        //            case "Username":
        //                sortedComments = sortedComments.OrderBy(c => c.Username);
        //                break;
        //            case "BookName":
        //                sortedComments = sortedComments.OrderBy(c => c.BookName);
        //                break;
        //        }

        //        CommentDataGrid.ItemsSource = sortedComments.ToList();
        //    }
        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string commentId = txtCommentId.Text.Trim();

            if (!string.IsNullOrEmpty(commentId))
            {
                // Tìm bình luận dựa trên CommentId kiểu chuỗi
                var comment = context.Comments.FirstOrDefault(c => c.CommentId == commentId);

                if (comment != null)
                {
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                    MessageBox.Show($"Comment with ID {commentId} has been deleted.");
                    LoadData(); // Refresh the data
                }
                else
                {
                    MessageBox.Show("Comment not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Comment ID.");
            }
        }

        private void ExportToFile_Click(object sender, RoutedEventArgs e)
        {
            var comments = context.Comments.Select(c => new
            {
                CommentId = c.CommentId,
                Username = c.User.Username,
                BookName = c.Book.BookName,
                Comment1 = c.Comment1,
            }).ToList();

            using (var writer = new StreamWriter("comments.txt"))
            {
                foreach (var comment in comments)
                {
                    writer.WriteLine($"CommentId: {comment.CommentId}, Username: {comment.Username}, BookName: {comment.BookName}, Comment: {comment.Comment1}");
                }
            }

            MessageBox.Show("Comments exported to comments.txt successfully.");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void CommentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }
    }
}
