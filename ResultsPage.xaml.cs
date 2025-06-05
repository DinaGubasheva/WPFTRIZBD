using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace rTRIZBD4
{
    public partial class ResultsPage : Page
    {
        public ObservableCollection<Result> Results { get; } = new ObservableCollection<Result>();
        private Result _selectedResult;

        public ResultsPage()
        {
            InitializeComponent();
            LoadResults();
            ResultsListView.ItemsSource = Results;
        }

        private void LoadResults()
        {
            Results.Add(new Result
            {
                FullName = "Иванов Иван Иванович",
                Score = "95 баллов",
                Location = "г. Москва, МГУ им. М.В. Ломоносова, 10-й корпус"
            });

            Results.Add(new Result
            {
                FullName = "Петров Петр Петрович",
                Score = "88 баллов",
                Location = "г. Санкт-Петербург, ИТМО, Главный корпус"
            });

            Results.Add(new Result
            {
                FullName = "Сидорова Анна Сергеевна",
                Score = "92 балла",
                Location = "г. Казань, КФУ, Институт вычислительной математики"
            });

            Results.Add(new Result
            {
                FullName = "Кузнецов Денис Олегович",
                Score = "79 баллов",
                Location = "г. Екатеринбург, УрФУ, Главный учебный корпус"
            });

            Results.Add(new Result
            {
                FullName = "Козлова Мария Игоревна",
                Score = "100 баллов",
                Location = "г. Новосибирск, НГУ, Главный корпус"
            });
        }

        private void ResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedResult = ResultsListView.SelectedItem as Result;
            EditButton.IsEnabled = DeleteButton.IsEnabled = _selectedResult != null;
        }

        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            var newResult = new Result
            {
                FullName = "Новый участник",
                Score = "0 баллов",
                Location = "Место проведения"
            };

            var dialog = new ResultEditDialog(newResult);
            if (dialog.ShowDialog() == true)
            {
                Results.Add(newResult);
                ResultsListView.SelectedItem = newResult;
            }
        }

        private void EditResult_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedResult == null)
            {
                MessageBox.Show("Выберите результат для редактирования");
                return;
            }

            var temp = new Result
            {
                FullName = _selectedResult.FullName,
                Score = _selectedResult.Score,
                Location = _selectedResult.Location
            };

            var dialog = new ResultEditDialog(temp);
            if (dialog.ShowDialog() == true)
            {
                _selectedResult.FullName = temp.FullName;
                _selectedResult.Score = temp.Score;
                _selectedResult.Location = temp.Location;
            }
        }

        private void DeleteResult_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedResult != null)
            {
                Results.Remove(_selectedResult);
                _selectedResult = null;
                EditButton.IsEnabled = DeleteButton.IsEnabled = false;
            }
        }
    }
}
