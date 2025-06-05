using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace rTRIZBD4
{
    public partial class ParticipantsPage : Page
    {
        public ObservableCollection<Participant> Participants { get; } = new ObservableCollection<Participant>();
        private Participant _selectedParticipant;

        public ParticipantsPage()
        {
            InitializeComponent();
            
            Participants.Add(new Participant
            {
                FullName = "Иванов Иван Иванович",
                BirthDate = "01.01.2008",
                School = "Школа №1",
                Class = "9А"
            });

            Participants.Add(new Participant
            {
                FullName = "Петрова Анна Сергеевна",
                BirthDate = "15.03.2009",
                School = "Лицей №5",
                Class = "8Б"
            });

            Participants.Add(new Participant
            {
                FullName = "Сидоров Николай Павлович",
                BirthDate = "22.11.2007",
                School = "Гимназия №10",
                Class = "10В"
            });

            ParticipantsListView.ItemsSource = Participants;
        }

        private void ParticipantsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedParticipant = ParticipantsListView.SelectedItem as Participant;
            EditButton.IsEnabled = DeleteButton.IsEnabled = _selectedParticipant != null;
        }

        private void AddParticipant_Click(object sender, RoutedEventArgs e)
        {
            var newParticipant = new Participant
            {
                FullName = "Новый участник",
                BirthDate = "01.01.2010",
                School = "Новая школа",
                Class = "7А"
            };

            var dialog = new ParticipantEditDialog(newParticipant);
            if (dialog.ShowDialog() == true)
            {
                Participants.Add(newParticipant);
                ParticipantsListView.SelectedItem = newParticipant;
            }
        }

        private void EditParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedParticipant == null)
            {
                MessageBox.Show("Выберите участника для редактирования");
                return;
            }

            var temp = new Participant
            {
                FullName = _selectedParticipant.FullName,
                BirthDate = _selectedParticipant.BirthDate,
                School = _selectedParticipant.School,
                Class = _selectedParticipant.Class
            };

            var dialog = new ParticipantEditDialog(temp);
            if (dialog.ShowDialog() == true)
            {
                _selectedParticipant.FullName = temp.FullName;
                _selectedParticipant.BirthDate = temp.BirthDate;
                _selectedParticipant.School = temp.School;
                _selectedParticipant.Class = temp.Class;
            }
        }

        private void DeleteParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedParticipant != null)
            {
                Participants.Remove(_selectedParticipant);
                _selectedParticipant = null;
                EditButton.IsEnabled = DeleteButton.IsEnabled = false;
            }
        }
    }
}
