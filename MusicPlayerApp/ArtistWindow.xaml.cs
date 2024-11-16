using MusicPlayerApp.BLL.Services;
using MusicPlayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ArtistWindow.xaml
    /// </summary>
    public partial class ArtistWindow : Window
    {
        private SongServices _service = new();
        public User? CurrentUser { get; set; }
        public ObservableCollection<Song> FilteredSongs { get; set; }
        private DetailWindow detailWindow;

        public ArtistWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadSongs();
        }

        private void loadSongs()
        {
            this.DataContext = CurrentUser;
            Console.WriteLine("image : " + CurrentUser.Image);
            var allSongs = _service.GetAllListSongsWithUserID(CurrentUser.UserId);
            FilteredSongs = new ObservableCollection<Song>(allSongs);
            SongsListBox.ItemsSource = null;
            SongsListBox.ItemsSource = FilteredSongs;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSongWindow c = new CreateSongWindow();
            c.CurrentUser = CurrentUser;
            c.ShowDialog();
            loadSongs();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng Song từ CommandParameter của nút
            var button = sender as Button;
            var selected = button?.CommandParameter as Song;

            // Mở cửa sổ CreateSongWindow với bài hát đã chọn
            CreateSongWindow detail = new CreateSongWindow();
            detail.EditedOne = selected;
            detail.ShowDialog();

            // Tải lại danh sách bài hát sau khi cập nhật
            loadSongs();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) || string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                loadSongs();
                return;
            }

            var keyword = SearchBox.Text.ToLower();
            int userID = CurrentUser.UserId;
            var filteredSongs = _service.GetAllListSongsWithUserID(userID)
                .Where(s => s.Title.ToLower().Contains(keyword) || s.User.Username.ToLower().Contains(keyword))
                .Take(3);

            FilteredSongs.Clear();
            foreach (var song in filteredSongs)
            {
                FilteredSongs.Add(song);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng Song từ CommandParameter của nút
            var button = sender as Button;
            var songToDelete = button?.CommandParameter as Song;

            // Xác nhận xóa
            var result = MessageBox.Show($"Are you sure you want to delete '{songToDelete.Title}'?",
                                         "Delete Confirmation",
                                         MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Xóa bài hát khỏi danh sách
                _service.RemoveSong(songToDelete);  // Giả sử `Songs` là danh sách các bài hát

                // Tải lại danh sách hiển thị để cập nhật
                loadSongs();
            }
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
            if (detailWindow != null)
            {
                detailWindow.Close();
            }
            ThemesWindow theme = new();
            theme.CurrentUser = CurrentUser;
            theme.Show();
            this.Close();
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

        private void Workspace_Click(object sender, RoutedEventArgs e)
        {
            loadSongs();
        }

        private void SongsListBox_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SongsListBox.SelectedItem;
            if (selectedItem is Song selectedSong)
            {
                if (detailWindow == null || !detailWindow.IsVisible)
                {
                    detailWindow = new DetailWindow
                    {
                        CurrentUser = CurrentUser,
                        SelectedSong = selectedSong,
                    };
                    detailWindow.Show();
                }

                detailWindow.UpdateSongInfo(selectedSong);
            }
        }
    }
}
