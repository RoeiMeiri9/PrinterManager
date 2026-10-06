using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml.Media.Imaging;

public static class IconExtractor
{
    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool DestroyIcon(IntPtr hIcon);

    public static BitmapImage GetIconFromDll(string dllPath, int iconIndex)
    {
        IntPtr hIcon = ExtractIcon(IntPtr.Zero, dllPath, iconIndex);

        if (hIcon == IntPtr.Zero || hIcon == (IntPtr)1)
        {
            return new BitmapImage();
        }

        try
        {
            using (Icon icon = Icon.FromHandle(hIcon))
            using (Bitmap bitmap = icon.ToBitmap())
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream.AsRandomAccessStream());
                return bitmapImage;
            }
        }
        finally
        {
            DestroyIcon(hIcon);
        }
    }
}