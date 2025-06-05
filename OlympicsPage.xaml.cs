using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace rTRIZBD4
{
    public partial class OlympicsPage : Page
    {
        public ObservableCollection<Olympiad> Olympiads { get; } = new ObservableCollection<Olympiad>();
        private Olympiad _selectedOlympiad;

        public OlympicsPage()
        {
            InitializeComponent();

            Olympiads.Add(new Olympiad { Name = "Математическая олимпиада", Date = "15.10.2024" });
            Olympiads.Add(new Olympiad { Name = "Физическая олимпиада", Date = "22.10.2024" });
            Olympiads.Add(new Olympiad { Name = "Химическая олимпиада", Date = "29.10.2024" });
            Olympiads.Add(new Olympiad { Name = "Информатика", Date = "05.11.2024" });
            Olympiads.Add(new Olympiad { Name = "Биология", Date = "12.11.2024" });

            OlympiadsListBox.ItemsSource = Olympiads;
        }

        private void OlympiadsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedOlympiad = OlympiadsListBox.SelectedItem as Olympiad;
            EditButton.IsEnabled = DeleteButton.IsEnabled = _selectedOlympiad != null;
        }

        private void AddOlympiad_Click(object sender, RoutedEventArgs e)
        {
            var newOlympiad = new Olympiad { Name = "Новая олимпиада", Date = "01.01.2025" };
            Olympiads.Add(newOlympiad);
            OlympiadsListBox.SelectedItem = newOlympiad;
        }

        private void EditOlympiad_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOlympiad == null)
            {
                MessageBox.Show("Выберите олимпиаду для редактирования");
                return;
            }

            var temp = new Olympiad
            {
                Name = _selectedOlympiad.Name,
                Date = _selectedOlympiad.Date
            };

            var dialog = new EditDialog(temp);
            if (dialog.ShowDialog() == true)
            {
                _selectedOlympiad.Name = temp.Name;
                _selectedOlympiad.Date = temp.Date;
            }
        }

        private void DeleteOlympiad_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOlympiad != null)
            {
                Olympiads.Remove(_selectedOlympiad);
                _selectedOlympiad = null;
                EditButton.IsEnabled = DeleteButton.IsEnabled = false;
            }
        }
    }

    public class Olympiad : INotifyPropertyChanged
    {
        private string _name;
        private string _date;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
