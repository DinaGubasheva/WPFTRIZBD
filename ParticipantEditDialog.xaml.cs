using System.Windows;

namespace rTRIZBD4
{
    public partial class ParticipantEditDialog : Window
    {
        public Participant Participant { get; set; }

        public ParticipantEditDialog(Participant participant)
        {
            InitializeComponent();
            Participant = participant;
            DataContext = Participant;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
