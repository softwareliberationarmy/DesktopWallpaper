using System;
using System.Collections.Generic;
using WallpaperManager;

namespace RandomWallpaperService
{
    static class Program
    {
        private static string _imageDirectory = "C:\\Images\\";

        static void Main()
        {
            string imageFile = GetRandomWallpaperImage();
            if (!string.IsNullOrEmpty(imageFile))
            {
                Wallpaper.Set(imageFile);
            }
        }

        private static string GetRandomWallpaperImage()
        {
            List<string> images = Wallpaper.GetImages(_imageDirectory);
            if (images.Count > 0)
            {
                Random rnd = new Random();
                int wallpaperIndex = rnd.Next(0, images.Count - 1);
                return images[wallpaperIndex];
            }
            return null;
        }
    }
}
