using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

namespace WallpaperManager
{
    public class Wallpaper
    {
        [DllImport("user32.dll")]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 0x14;
        private const int SPIF_UPDATEINIFILE = 0x1;
        private const int SPIF_SENDWININICHANGE = 0x2;

        public static void Set(string FileName)
        {
            Image img = Image.FromFile(FileName);
            int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, FileName, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static List<string> GetImages(string ImageDirectory)
        {
            return (from img in Directory.EnumerateFiles(ImageDirectory) 
                    where img.EndsWith(".bmp") || img.EndsWith(".jpg")
                    select img).ToList();
        }

    }
}
