using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rTRIZBD4
{
    public class Participant : INotifyPropertyChanged
    {
        private string _fullName;
        private string _birthDate;
        private string _school;
        private string _class;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string School
        {
            get => _school;
            set
            {
                if (_school != value)
                {
                    _school = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Class
        {
            get => _class;
            set
            {
                if (_class != value)
                {
                    _class = value;
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
