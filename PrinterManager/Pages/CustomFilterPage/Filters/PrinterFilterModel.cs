namespace PrinterManager.Pages.CustomFilterPage
{
    public partial class PrinterFilterModel : FilterModler
    {

        private string _name = string.Empty;
        private string _status = string.Empty;
        private int _jobsInQueue = EMPTY;
        private string _serverName = string.Empty;
        private string _comments = string.Empty;
        private bool _isShared = false;
        private string _location = string.Empty;
        private string _shareName = string.Empty;
        private string _driverName = string.Empty;
        private string _driverVersion = string.Empty;
        private string _provider = string.Empty;
        private string _driverType = string.Empty;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public int JobsInQueue
        {
            get => _jobsInQueue;
            set { _jobsInQueue = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public string ServerName
        {
            get => _serverName;
            set { _serverName = value; OnPropertyChanged(); }
        }

        public string Comments
        {
            get => _comments;
            set { _comments = value; OnPropertyChanged(); }
        }

        public bool IsShared
        {
            get => _isShared;
            set { _isShared = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(); }
        }

        public string ShareName
        {
            get => _shareName;
            set { _shareName = value; OnPropertyChanged(); }
        }

        public string DriverName
        {
            get => _driverName;
            set { _driverName = value; OnPropertyChanged(); }
        }

        public string DriverVersion
        {
            get => _driverVersion;
            set { _driverVersion = value; OnPropertyChanged(); }
        }

        public string Provider
        {
            get => _provider;
            set { _provider = value; OnPropertyChanged(); }
        }

        public string DriverType
        {
            get => _driverType;
            set { _driverType = value; OnPropertyChanged(); }
        }
    }
}
