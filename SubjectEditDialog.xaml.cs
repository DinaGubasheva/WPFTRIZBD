using System.Windows;

namespace rTRIZBD4
{
    public partial class SubjectEditDialog : Window
    {
        public string SubjectName { get; set; }

        public SubjectEditDialog(string initialName)
        {
            InitializeComponent();
            SubjectName = initialName;
            NameTextBox.Text = initialName;
            NameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectName = NameTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
