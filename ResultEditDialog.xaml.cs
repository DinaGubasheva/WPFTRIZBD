using System.Windows;

namespace rTRIZBD4
{
    public partial class ResultEditDialog : Window
    {
        public Result Result { get; set; }

        public ResultEditDialog(Result result)
        {
            InitializeComponent();
            Result = result;
            DataContext = Result;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
