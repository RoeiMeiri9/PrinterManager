using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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

        public ColumnSettings ColumnSettings { get; } = new();
        private ScrollViewer? _listScroller;
        public CustomFiltersPage()
        {
            InitializeComponent();
            LoadInitialPrinters();
        }

        private void LoadInitialPrinters()
        {
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


        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is FrameworkElement { Tag: string tag } && int.TryParse(tag, out var index))
                ColumnSettings.Resize(index, e.HorizontalChange);
        }

        private void SubNavListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubNavListView.SelectedItem is ListViewItem selectedItem)
            {
            }
        }

        private void FiltersListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (_listScroller != null) return;

            _listScroller = FindDescendant<ScrollViewer>(FiltersListView);
            if (_listScroller != null)
                _listScroller.ViewChanged += ListScroller_ViewChanged;
        }

        // Keep the header's horizontal position equal to the list's
        private void ListScroller_ViewChanged(object? sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_listScroller != null)
                HeaderScroller.ChangeView(_listScroller.HorizontalOffset, null, null, true);
        }

        private static T? FindDescendant<T>(DependencyObject root) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is T match) return match;

                var result = FindDescendant<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }
}
