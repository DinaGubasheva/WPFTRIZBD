using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace rTRIZBD4
{
    public partial class OrganizersPage : Page
    {
        public ObservableCollection<string> Organizers { get; } = new ObservableCollection<string>();
        private string _selectedOrganizer;

        public OrganizersPage()
        {
            InitializeComponent();

            Organizers.Add("Иванов Иван Иванович");
            Organizers.Add("Петрова Анна Сергеевна");
            Organizers.Add("Сидоров Дмитрий Викторович");
            Organizers.Add("Кузнецова Ольга Петровна");
            Organizers.Add("Смирнов Алексей Николаевич");

            OrganizersListView.ItemsSource = Organizers;
        }

        private void OrganizersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedOrganizer = OrganizersListView.SelectedItem as string;
            EditButton.IsEnabled = DeleteButton.IsEnabled = _selectedOrganizer != null;
        }

        private void AddOrganizer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OrganizerEditDialog("");
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.OrganizerName))
            {
                Organizers.Add(dialog.OrganizerName);
            }
        }

        private void EditOrganizer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedOrganizer))
            {
                MessageBox.Show("Выберите организатора для редактирования");
                return;
            }

            var dialog = new OrganizerEditDialog(_selectedOrganizer);
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.OrganizerName))
            {
                int index = Organizers.IndexOf(_selectedOrganizer);

                if (index >= 0)
                {
                    Organizers[index] = dialog.OrganizerName;

                    OrganizersListView.SelectedItem = dialog.OrganizerName;
                }
            }
        }

        private void DeleteOrganizer_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedOrganizer))
            {
                Organizers.Remove(_selectedOrganizer);

                _selectedOrganizer = null;
                OrganizersListView.SelectedItem = null;

                EditButton.IsEnabled = DeleteButton.IsEnabled = false;
            }
        }
    }
}
