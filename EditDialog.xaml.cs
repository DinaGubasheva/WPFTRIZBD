using System.Windows;

namespace rTRIZBD4
{
    public partial class EditDialog : Window
    {
        public Olympiad EditingOlympiad { get; set; }

        public EditDialog(Olympiad olympiad)
        {
            InitializeComponent();
            EditingOlympiad = olympiad;
            DataContext = EditingOlympiad;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
