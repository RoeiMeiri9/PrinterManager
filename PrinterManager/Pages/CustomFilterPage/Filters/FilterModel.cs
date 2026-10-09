using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrinterManager.Pages.CustomFilterPage
{

    public partial class FilterModler : INotifyPropertyChanged
    {
        public const int EMPTY = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
