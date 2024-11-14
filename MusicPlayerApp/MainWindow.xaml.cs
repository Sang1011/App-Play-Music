using MusicPlayerApp.BLL.Services;
using MusicPlayerApp.DAL.Entities;
using System.Collections.ObjectModel;
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

namespace MusicPlayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User? CurrentUser { get; set; }
        public ObservableCollection<Song> FilteredSongs { get; set; }

        private SongServices _service = new();
        private PlaylistServices _playlist = new();
        private DetailWindow detailWindow;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Data();
            if (CurrentUser != null)
            {
                LoginButton.IsEnabled = false;
            }
            else
            {
                LoginButton.IsEnabled = true;
            }
        }

        private void Load_Data()
        {
            var allSongs = _service.GetList();
            FilteredSongs = new ObservableCollection<Song>(allSongs);
            SongsListBox.ItemsSource = null;
            SongsListBox.ItemsSource = FilteredSongs;
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


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(SearchBox.Text) || string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                Load_Data();
                return;
            }

            var keyword = SearchBox.Text.ToLower();

            var filteredSongs = _service.GetList()
                .Where(s => s.Title.ToLower().Contains(keyword) || s.User.Username.ToLower().Contains(keyword))
                .Take(3);

            FilteredSongs.Clear();
            foreach (var song in filteredSongs)
            {
                FilteredSongs.Add(song);
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(detailWindow != null)
            {
                detailWindow.Close();
            }
            LoginWindow login = new();
            login.ShowDialog();
        }

        private void SongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Load_Data();
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