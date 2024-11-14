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
    /// Interaction logic for PlaylistShow.xaml
    /// </summary>
    public partial class PlaylistShow : Window
    {
        private PlaylistServices _playlist = new();
        public User CurrentUser { get; set; }

        public Song? SelectedSong { get; set; }

        public bool AddOne { get; set; }
        public PlaylistShow()
        {
            InitializeComponent();
        }

        public void Window_Onload(object sender, RoutedEventArgs e)
        {
            playlistListBox.ItemsSource = null;
            if(_playlist.GetPlaylist(CurrentUser.UserId) == null){
                playlistListBox.ItemsSource = "Empty";
            }
            else
            {
                playlistListBox.ItemsSource = _playlist.GetPlaylist(CurrentUser.UserId);
            }
        }

        private void playlistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = playlistListBox.SelectedItem;

            if (selectedItem != null)
            {
                if (selectedItem is Playlist selectedPlaylist)
                {
                    if (AddOne)
                    {
                        if (selectedPlaylist.Songs.Count > 10) 
                        {
                            MessageBox.Show("Cannot add more than 10 songs into playlist. Choose other playlist!");
                            return;
                        }
                        int result = _playlist.AddSongToPlaylist(selectedPlaylist.PlaylistId, SelectedSong);
                        if (result == 1)
                        {
                            MessageBox.Show("Add song successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Add song failed!");
                            this.Close();
                        }
                    }
                    else
                    {
                        FavoriteWindow favorite = new();
                        favorite.CurrentUser = CurrentUser;
                        favorite.PlaylistChoose = selectedPlaylist.PlaylistId;
                        favorite.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid selection type.");
                }
            }
        }
    }
}
