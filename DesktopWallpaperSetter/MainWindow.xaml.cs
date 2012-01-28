using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DesktopWallpaperSetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private members
        private string _imageDirectory = "C:\\Images\\";
        #endregion

        #region ctors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region window and control events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImageList();
        }

        private void cmbImageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ImageIsSelected())
            {
                string imageFile = GetImagePath();
                if (!File.Exists(imageFile))
                {
                    MessageBox.Show("Hmm, that's weird.  That file doesn't exist", "Uh, this is awkward");
                }
                else
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(imageFile);
                    img.EndInit();
                    imgPreview.Source = img;
                    //imgPreview.ClipToBounds = true;
                }
            }

        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            if (!ImageIsSelected())
            {
                MessageBox.Show("Please select an image", "Very Funny");
            }
            else
            {
                WallpaperManager.Wallpaper.Set(GetImagePath());
                MessageBox.Show("Done", "Success");
            }
        }
        #endregion

        #region private methods
        private void LoadImageList()
        {
            List<string> images = WallpaperManager.Wallpaper.GetImages(_imageDirectory);
            cmbImageList.ItemsSource = images;
        }

        private bool ImageIsSelected()
        {
            return (cmbImageList.SelectedIndex > -1);
        }

        private string GetImagePath()
        {
            return System.IO.Path.Combine(_imageDirectory, cmbImageList.SelectedValue.ToString());
        }
        #endregion
    }
}
