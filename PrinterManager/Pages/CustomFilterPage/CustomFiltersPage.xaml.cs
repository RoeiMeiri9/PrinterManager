using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PrinterManager.Pages.CustomFilterPage;
using PrinterManager.Pages.CustomFilterPage.Components.TreeViewLeaf;
using PrinterManager.Resources;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace PrinterManager.Pages
{
    public sealed partial class CustomFiltersPage : Page
    {
        public ObservableCollection<PrinterFilterModel> PrinterFiltersList { get; } = [];

        public List<FilterLeaf> FiltersList = [];

        public CustomFiltersPage()
        {
            InitializeComponent();
            LoadFilters();
            LoadInitialPrinters();
        }

        private void LoadFilters()
        {
            var printersRoot = new FilterLeaf { Name = "Printers", LeafIcon = Icons.Printer };
            printersRoot.Children.Add(new FilterLeaf { Name = "All Printers", LeafIcon = Icons.Filter, DisplayTotalItems = Visibility.Visible, TotalItems = 2 });
            printersRoot.Children.Add(new FilterLeaf { Name = "Printers Nor Ready", LeafIcon = Icons.Filter });
            printersRoot.Children.Add(new FilterLeaf { Name = "Printers With Jobs", LeafIcon = Icons.Filter });
            FiltersList.Add(printersRoot);

            var driversRoot = new FilterLeaf { Name = "Drivers", LeafIcon = Icons.Driver };
            driversRoot.Children.Add(new FilterLeaf { Name = "All Drivers", LeafIcon = Icons.Filter, DisplayTotalItems = Visibility.Visible, TotalItems = 7 });
            FiltersList.Add(driversRoot);
        }

        private void LoadInitialPrinters()
        {

            //PrintersTable.Columns.Add(new TableColumn { Header = "Port", Path = "PortName", Width = 100 });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Office-HP-LaserJet",
                ServerName = "192.168.1.100",
                Status = "Ready",
                DriverName = "HP Universal Printing PCL 6",
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Pending",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });

            PrinterFiltersList.Add(new PrinterFilterModel
            {
                Name = "Warehouse-Zebra-Label",
                ServerName = "192.168.1.105",
                Status = "Offline",
                DriverName = "Zebra ZPL Driver"
            });
        }
        //private void SubNavListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (SubNavListView.SelectedItem is ListViewItem selectedItem)
        //    {
        //    }
        //}

    }
}
