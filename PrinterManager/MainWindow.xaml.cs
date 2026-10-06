
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using PrinterManager.Pages;
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
            InitializeWindow();
            InitializeFrame();
        }


        private void InitializeWindow()
        {
            ExtendsContentIntoTitleBar = true;
            Title = AppTitle;
            SetTitleBar(titleBar);
            SetIcon();
            UpdateSelectedIcon(DefaultDetailsViewItem);
        }

        private void SetIcon()
        {
            string iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Icons", "IconGroup51.ico");
            if (File.Exists(iconPath))
                AppWindow.SetIcon(iconPath);
            else
                System.Diagnostics.Debug.WriteLine($"Icon not found: {iconPath}");
        }

        private void InitializeFrame()
        {
            navFrame.Navigate(typeof(CustomFiltersPage));
        }


        private void ViewMode_Click(object sender, RoutedEventArgs e)
        {
            // בלחיצה: עדכון האייקון לפי הפריט שנלחץ
            if (sender is RadioMenuFlyoutItem item)
            {
                UpdateSelectedIcon(item);
            }
        }

        private void UpdateSelectedIcon(RadioMenuFlyoutItem item)
        {
            if (item == null) return;

            if (item.Icon is FontIcon fontIcon)
            {
                SelectedIconPresenter.Content = new FontIcon
                {
                    Glyph = fontIcon.Glyph,
                    FontFamily = fontIcon.FontFamily,
                    FontSize = 20
                };
            }
            else if (item.Icon is SymbolIcon symbolIcon)
            {
                SelectedIconPresenter.Content = new SymbolIcon
                {
                    Symbol = symbolIcon.Symbol
                };
            }
        }
    }
}