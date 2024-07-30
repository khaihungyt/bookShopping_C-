using System.Windows;

namespace PRN212_Assignment
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            MessageText.Text = message;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        public static void Show(string message)
        {
            CustomMessageBox messageBox = new CustomMessageBox(message);
            messageBox.ShowDialog();
        }
    }
}
