using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;

namespace PrinterManager.Controls;

[ContentProperty(Name = nameof(Columns))]
public sealed partial class DataTable : UserControl
{
    public TableColumnCollection Columns { get; } = new();

    public DataTable()
    {
        InitializeComponent();
        Columns.CollectionChanged += Columns_CollectionChanged;
    }

    // ---------- dependency properties ----------
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(DataTable),
            new PropertyMetadata(null, (d, e) => ((DataTable)d).RowsList.ItemsSource = e.NewValue));

    public object? ItemsSource
    {
        get => GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    // rows bind their Width to this
    public static readonly DependencyProperty TotalWidthProperty =
        DependencyProperty.Register(nameof(TotalWidth), typeof(double), typeof(DataTable),
            new PropertyMetadata(0.0));

    public double TotalWidth
    {
        get => (double)GetValue(TotalWidthProperty);
        private set => SetValue(TotalWidthProperty, value);
    }

    // ---------- selection ----------
    public object? SelectedItem
    {
        get => RowsList.SelectedItem;
        set => RowsList.SelectedItem = value;
    }

    public event SelectionChangedEventHandler? SelectionChanged;
    private void RowsList_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
        SelectionChanged?.Invoke(this, e);

    // ---------- columns ----------
    private void Columns_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
            foreach (TableColumn c in e.OldItems) c.PropertyChanged -= Column_PropertyChanged;
        if (e.NewItems != null)
            foreach (TableColumn c in e.NewItems) c.PropertyChanged += Column_PropertyChanged;
        UpdateTotalWidth();
    }

    private void Column_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TableColumn.DisplayWidth))
            UpdateTotalWidth();
    }

    private void UpdateTotalWidth() => TotalWidth = Columns.Sum(c => c.DisplayWidth);

    private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: TableColumn col })
            col.Resize(e.HorizontalChange);
    }

    internal DataTemplate GetCellTemplate(TableColumn col) =>
        col.CellTemplate
        ?? (DataTemplate)Resources[col.IsPrimary ? "PrimaryTextCellTemplate" : "TextCellTemplate"];

    // ---------- keep the header scrolled with the rows ----------
    private ScrollViewer? _listScroller;

    private void RowsList_Loaded(object sender, RoutedEventArgs e)
    {
        if (_listScroller != null) return;
        _listScroller = FindDescendant<ScrollViewer>(RowsList);
        if (_listScroller != null)
            _listScroller.ViewChanged += (_, _) =>
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