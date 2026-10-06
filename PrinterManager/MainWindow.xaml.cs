
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Windows.ApplicationModel;
using WinRT.Interop;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PrinterManager
{
    public sealed partial class MainWindow : Window
    {
        public string AppTitle => Windows.ApplicationModel.Package.Current.DisplayName;

        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            Title = AppTitle;
            SetTitleBar(titleBar);
            string iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "IconGroup51.ico");
            if (File.Exists(iconPath))
                AppWindow.SetIcon(iconPath);
            else
                System.Diagnostics.Debug.WriteLine($"Icon not found: {iconPath}");
        }
    }
}