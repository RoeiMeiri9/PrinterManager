using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;

namespace PrinterManager.Controls;

public class TableColumn : INotifyPropertyChanged
{
    private double _width = 150;
    private bool _isVisible = true;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Raise([CallerMemberName] string? n = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    /// <summary>Text shown in the header.</summary>
    public string Header { get; set; } = "";

    /// <summary>Name of the row-item property to show (e.g. "Name"). Ignored if CellTemplate is set.</summary>
    public string Path { get; set; } = "";

    public double MinWidth { get; set; } = 80;

    /// <summary>Bold, primary-colored text (like the printer name).</summary>
    public bool IsPrimary { get; set; }

    /// <summary>Optional custom cell. Its DataContext is the whole row item.</summary>
    public DataTemplate? CellTemplate { get; set; }

    public double Width
    {
        get => _width;
        set { _width = value; Raise(); Raise(nameof(DisplayWidth)); }
    }

    public bool IsVisible
    {
        get => _isVisible;
        set { _isVisible = value; Raise(); Raise(nameof(DisplayWidth)); Raise(nameof(CellVisibility)); }
    }

    // what the header/cells actually bind to
    public double DisplayWidth => _isVisible ? _width : 0;
    public Visibility CellVisibility => _isVisible ? Visibility.Visible : Visibility.Collapsed;

    internal void Resize(double delta) => Width = Math.Max(MinWidth, _width + delta);
}

public class TableColumnCollection : ObservableCollection<TableColumn> { }