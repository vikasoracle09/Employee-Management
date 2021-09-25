using System.ComponentModel;

namespace EmployeeApps
{
    /// <summary>
    /// Employee Data
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _email;
        private string _status;
        private string _gender;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
