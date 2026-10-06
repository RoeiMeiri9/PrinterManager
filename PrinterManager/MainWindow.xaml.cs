
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using Windows.ApplicationModel;


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

            string imageresPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "imageres.dll"
            );

            BitmapImage printerIcon = IconExtractor.GetIconFromDll(imageresPath, 46);

            if (printerIcon != null)
            {
                // השמה ל-Image שנמצא ב-TitleBar ב-XAML
                TitleBarIcon.Source = printerIcon;
            }

            SetTitleBar(titleBar);
        }
    }
}