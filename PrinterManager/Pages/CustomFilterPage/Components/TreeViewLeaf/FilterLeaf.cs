using Microsoft.UI.Xaml;
using PrinterManager.Resources;
using System.Collections.ObjectModel;

namespace PrinterManager.Pages.CustomFilterPage.Components.TreeViewLeaf
{
    public class FilterLeaf
    {
        public required string Name { get; set; }
        public required Icons LeafIcon { get; set; }
        public Visibility DisplayTotalItems { get; set; } = Visibility.Collapsed;
        public int TotalItems { get; set; } = 0;
        public ObservableCollection<FilterLeaf> Children { get; set; } = [];
    }
}
