using System.Windows;

namespace rTRIZBD4
{
    public partial class OlympiadEditDialog : Window
    {
        public Olympiad Olympiad { get; set; }

        public OlympiadEditDialog(Olympiad olympiad)
        {
            InitializeComponent();
            Olympiad = olympiad;
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
