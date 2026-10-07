using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PrinterManager.Controls;
using PrinterManager.Pages.CustomFilterPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

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
