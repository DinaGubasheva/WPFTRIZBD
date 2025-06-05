using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rTRIZBD4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string pageName = clickedButton.Tag as string;
                if (!string.IsNullOrEmpty(pageName))
                {
                    try
                    {
                        Uri pageUri = new Uri(pageName, UriKind.Relative);
                        MainFrame.Navigate(pageUri);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки страницы: {ex.Message}", "Ошибка навигации", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
