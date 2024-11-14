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
    /// Interaction logic for FavoriteWindow.xaml
    /// </summary>
    public partial class FavoriteWindow : Window
    {
        public User CurrentUser {  get; set; }
        public int PlaylistChoose { get; set; }

        public PlaylistServices _playlist = new();

        public SongServices _service = new();
        private DetailWindow detailWindow;

        public FavoriteWindow()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (CurrentUser != null)
            {
                LoginButton.IsEnabled = false;
            }
            else
            {
                LoginButton.IsEnabled = true;
            }
            FavoriteListBox.ItemsSource = null;
            Playlist? p = _playlist.GetOne(PlaylistChoose);
            if (p.Songs != null && p.Songs.Count > 0)
            {
                PlaylistName.Content = p.Name;
                FavoriteListBox.ItemsSource = p.Songs;
            }
            else
            {
                MessageBox.Show("No song available. You need to add some songs!");
            }
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
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

        private void ThemesButton_Click(object sender, RoutedEventArgs e)
        {
            if (detailWindow != null)
            {
                detailWindow.Close();
            }
            ThemesWindow theme = new();
            theme.CurrentUser = CurrentUser;
            theme.Show();
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
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var song = button.DataContext as Song;
                if (song != null)
                {
                    if (MessageBox.Show($"Are you sure you want to remove this song from your playlist?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        bool result = _playlist.RemoveSongFromPlaylist(PlaylistChoose, song);

                        if (result)
                        {
                            MessageBox.Show(
                                "The song was successfully removed from your playlist.",
                                "Song Removed",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to remove the song from your playlist. Please try again.",
                                "Remove Failed",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                        }

                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Unable to identify the selected song. Please try again.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Playlist? p = _playlist.GetOne(PlaylistChoose);
            List<Song> playlistUser = new List<Song>(p.Songs);
            Button playButton = sender as Button;
            if (playButton?.DataContext is Song selectedSong)
            {
                if (detailWindow == null || !detailWindow.IsVisible)
                {
                    detailWindow = new DetailWindow
                    {
                        PlaylistUser = true,
                        CurrentUser = CurrentUser,
                        SelectedSong = selectedSong
                    };

                    detailWindow.Show();
                }

                detailWindow.UpdateSongInfo(selectedSong);
            }
        }

        private void Playlists_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
