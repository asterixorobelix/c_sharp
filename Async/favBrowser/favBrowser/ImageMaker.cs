using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace favBrowser
{
    public static class ImageMaker
    {
        public static Image MakeImageControl(byte[] bytes)
        {
            Image imageControl = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            imageControl.Source = bitmapImage;
            imageControl.Width = 25;
            imageControl.Height = 25;
            return imageControl;
        }
    }
}
