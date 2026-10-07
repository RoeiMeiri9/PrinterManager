using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;

namespace PrinterManager.Pages.CustomFilterPage;

public class ColumnSettings : INotifyPropertyChanged
{
    private const double MinName = 100, MinOther = 80;

    private double _name = 250, _server = 180, _status = 120, _driver = 220;
    private bool _serverVisible = true, _statusVisible = true, _driverVisible = true;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Notify([CallerMemberName] string? n = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    // ---- widths used by the header and the rows (0 when the column is hidden) ----
    public GridLength NameColumnWidth => new(_name);
    public GridLength ServerColumnWidth => new(_serverVisible ? _server : 0);
    public GridLength StatusColumnWidth => new(_statusVisible ? _status : 0);
    public GridLength DriverColumnWidth => new(_driverVisible ? _driver : 0);

    public double TotalWidth =>
        _name
        + (_serverVisible ? _server : 0)
        + (_statusVisible ? _status : 0)
        + (_driverVisible ? _driver : 0);

    // ---- visibility ----
    public bool ServerIsVisible { get => _serverVisible; set { _serverVisible = value; NotifyAll("Server"); } }
    public bool StatusIsVisible { get => _statusVisible; set { _statusVisible = value; NotifyAll("Status"); } }
    public bool DriverIsVisible { get => _driverVisible; set { _driverVisible = value; NotifyAll("Driver"); } }

    public Visibility ServerVisibility => _serverVisible ? Visibility.Visible : Visibility.Collapsed;
    public Visibility StatusVisibility => _statusVisible ? Visibility.Visible : Visibility.Collapsed;
    public Visibility DriverVisibility => _driverVisible ? Visibility.Visible : Visibility.Collapsed;

    // ---- called by the drag handles ----
    public void Resize(int column, double delta)
    {
        switch (column)
        {
            case 0: _name = Math.Max(MinName, _name + delta); Notify(nameof(NameColumnWidth)); break;
            case 1: _server = Math.Max(MinOther, _server + delta); Notify(nameof(ServerColumnWidth)); break;
            case 2: _status = Math.Max(MinOther, _status + delta); Notify(nameof(StatusColumnWidth)); break;
            case 3: _driver = Math.Max(MinOther, _driver + delta); Notify(nameof(DriverColumnWidth)); break;
        }
        Notify(nameof(TotalWidth));
    }

    private void NotifyAll(string column)
    {
        Notify(column + "ColumnWidth");
        Notify(column + "Visibility");
        Notify(column + "IsVisible");
        Notify(nameof(TotalWidth));
    }
}