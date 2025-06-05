using System.Windows;

namespace rTRIZBD4
{
    public partial class OrganizerEditDialog : Window
    {
        public string OrganizerName { get; set; }

        public OrganizerEditDialog(string initialName)
        {
            InitializeComponent();
            OrganizerName = initialName;
            NameTextBox.Text = initialName;
            NameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            OrganizerName = NameTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
