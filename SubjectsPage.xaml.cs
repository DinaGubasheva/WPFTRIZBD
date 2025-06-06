using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace rTRIZBD4
{
    public partial class SubjectsPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<string> _subjects;
        private string _selectedSubject;

        public ObservableCollection<string> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public SubjectsPage()
        {
            InitializeComponent();
            DataContext = this;

            Subjects = new ObservableCollection<string>
            {
                "Математика",
                "Физика",
                "Информатика",
                "Химия",
                "Биология"
            };
        }

        private void SubjectsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedSubject = SubjectsListView.SelectedItem as string;
            EditButton.IsEnabled = DeleteButton.IsEnabled = _selectedSubject != null;
        }

        private void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SubjectEditDialog("");
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.SubjectName))
            {
                Subjects.Add(dialog.SubjectName);
                SubjectsListView.SelectedItem = dialog.SubjectName;
            }
        }

        private void EditSubject_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSubject))
            {
                MessageBox.Show("Выберите предмет для редактирования");
                return;
            }

            var dialog = new SubjectEditDialog(_selectedSubject);
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.SubjectName))
            {
                int index = Subjects.IndexOf(_selectedSubject);
                if (index >= 0)
                {
                    Subjects[index] = dialog.SubjectName;
                    SubjectsListView.SelectedItem = dialog.SubjectName;
                }
            }
        }

        private void DeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedSubject))
            {
                Subjects.Remove(_selectedSubject);
                _selectedSubject = null;
                EditButton.IsEnabled = DeleteButton.IsEnabled = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
