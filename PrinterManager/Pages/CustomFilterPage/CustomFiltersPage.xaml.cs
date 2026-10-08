using Microsoft.UI.Xaml.Controls;
using PrinterManager.Controls;
using PrinterManager.Pages.CustomFilterPage;
using System.Collections.ObjectModel;


namespace PrinterManager.Pages
{

    public sealed partial class CustomFiltersPage : Page
    {
        public ObservableCollection<FilterModel> FiltersList { get; } = new ObservableCollection<FilterModel>();

        private ScrollViewer? _listScroller;
        public CustomFiltersPage()
        {
            InitializeComponent();
            LoadInitialPrinters();
        }

        private void LoadInitialPrinters()
        {

            PrintersTable.Columns.Add(new TableColumn { Header = "Port", Path = "PortName", Width = 100 });

            FiltersList.Add(new FilterModel
            {
                Name = "Office-HP-LaserJet",
                ServerName = "192.168.1.100",
                Status = "Ready",
                DriverName = "HP Universal Printing PCL 6"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Pending",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            FiltersList.Add(new FilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });
        }
        private void SubNavListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubNavListView.SelectedItem is ListViewItem selectedItem)
            {
            }
        }

    }
}
