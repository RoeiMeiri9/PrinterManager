using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrinterManager.Pages.CustomFilterPage
{
    public class FilterModel : INotifyPropertyChanged
    {
        private string _name;
        private string _serverName;
        private string _status;
        private string _driverName;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string ServerName
        {
            get => _serverName;
            set { _serverName = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public string DriverName
        {
            get => _driverName;
            set { _driverName = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}