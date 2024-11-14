using MusicPlayerApp.BLL.Services;
using MusicPlayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayerApp
{
    /// <summary>
    /// Interaction logic for ThemesWindow.xaml
    /// </summary>
    public partial class ThemesWindow : Window
    {
        private SongServices _services = new();
        private DetailWindow detailWindow;
        public User? CurrentUser { get; set; }
        public ThemesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            if (CurrentUser != null)
            {
                LoginButton.IsEnabled = false;
            }
            else
            {
                LoginButton.IsEnabled = true;
            }
        }

        private void LoadData()
        {
            SongsListBoxBallad.ItemsSource = null;
            SongsListBoxPop.ItemsSource = null;
            SongsListBoxRap.ItemsSource = null;
            SongsListBoxBallad.ItemsSource = _services.GetListByCategory("Ballad");
            SongsListBoxPop.ItemsSource = _services.GetListByCategory("Pop");
            SongsListBoxRap.ItemsSource = _services.GetListByCategory("Rap");
        }

        private void SongsListBoxPop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SongsListBoxPop.SelectedItem;
            if (selectedItem is Song selectedSong)
            {
                if (detailWindow == null || !detailWindow.IsVisible)
                {
                    detailWindow = new DetailWindow
                    {
                        SelectedSong = selectedSong
                    };

                    detailWindow.Show();
                }

                detailWindow.UpdateSongInfo(selectedSong);
            }
        }

        private void SongsListBoxRap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SongsListBoxRap.SelectedItem;
            if (selectedItem is Song selectedSong)
            {
                if (detailWindow == null || !detailWindow.IsVisible)
                {
                    detailWindow = new DetailWindow
                    {
                        SelectedSong = selectedSong
                    };
                    detailWindow.Show();
                }

                detailWindow.UpdateSongInfo(selectedSong);
            }
        }

        private void SongsListBoxBallad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SongsListBoxBallad.SelectedItem;
            if (selectedItem is Song selectedSong)
            {
                if (detailWindow == null || !detailWindow.IsVisible)
                {
                    detailWindow = new DetailWindow
                    {
                        SelectedSong = selectedSong
                    };
                    detailWindow.Show();
                }

                detailWindow.UpdateSongInfo(selectedSong);
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (detailWindow != null)
            {
                detailWindow.Close();
            }
            MainWindow main = new();
            main.CurrentUser = CurrentUser;
            main.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (detailWindow != null)
            {
                detailWindow.Close();
            }
            LoginWindow login = new();
            login.ShowDialog();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ThemesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Playlists_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Please login first", "Login Request", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (detailWindow != null)
            {
                detailWindow.Close();
            }
            PlaylistShow show = new();
            show.CurrentUser = CurrentUser;
            show.ShowDialog();
            this.Close();
        }
    }
}
