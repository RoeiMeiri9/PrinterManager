using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System.Collections.Specialized;

namespace PrinterManager.Controls;

public sealed partial class TableRow : StackPanel
{
    private DataTable? _table;

    public TableRow()
    {
        Orientation = Orientation.Horizontal;
        HorizontalAlignment = HorizontalAlignment.Left;
        Padding = new Thickness(0, 6, 0, 6);
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _table = FindAncestor<DataTable>(this);
        if (_table == null) return;

        _table.Columns.CollectionChanged += Columns_CollectionChanged;
        Rebuild();
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (_table != null)
            _table.Columns.CollectionChanged -= Columns_CollectionChanged;
        _table = null;
    }

    private void Columns_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) => Rebuild();

    private void Rebuild()
    {
        if (_table == null) return;

        Children.Clear();

        SetBinding(WidthProperty, new Binding
        {
            Source = _table,
            Path = new PropertyPath(nameof(DataTable.TotalWidth))
        });

        foreach (var col in _table.Columns)
        {
            var cell = new ContentControl
            {
                Padding = new Thickness(12, 0, 12, 0),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center,
                ContentTemplate = _table.GetCellTemplate(col)
            };

            cell.SetBinding(WidthProperty, new Binding
            {
                Source = col,
                Path = new PropertyPath(nameof(TableColumn.DisplayWidth))
            });
            cell.SetBinding(VisibilityProperty, new Binding
            {
                Source = col,
                Path = new PropertyPath(nameof(TableColumn.CellVisibility))
            });

            // custom template -> the whole row item; otherwise just the named property
            cell.SetBinding(ContentControl.ContentProperty, col.CellTemplate != null
                ? new Binding()
                : new Binding { Path = new PropertyPath(col.Path) });

            Children.Add(cell);
        }
    }

    private static T? FindAncestor<T>(DependencyObject start) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(start);
        while (parent != null)
        {
            if (parent is T match) return match;
            parent = VisualTreeHelper.GetParent(parent);
        }
        return null;
    }
}