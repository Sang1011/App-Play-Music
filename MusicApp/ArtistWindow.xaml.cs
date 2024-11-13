using MusicApp.BLL.Services;
using MusicApp.DAL.Entities;
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

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for ArtistWindow.xaml
    /// </summary>
    public partial class ArtistWindow : Window
    {
        private SongServices _service = new();
        private User? currentUser { get; set; }
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
            User user = new User
            {
                UserId = 3,
                Username = "Son Tung MTP",
                Password = "1235",
                CreatedDate = new DateOnly(),  // Sử dụng DateTime thay cho DateOnly
                Role = "Artist",
                Image = "Resources/Images/Son Tung MTP.jpg"
            };
            currentUser = user;
            this.DataContext = currentUser;
            SongsListBox.ItemsSource = _service.GetAllListSongsWithUserID(currentUser.UserId);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close(); // Đóng ArtistWindow
        }

        private void YourSongsButton_Click(object sender, RoutedEventArgs e)
        {
            loadSongs();
        }
                private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
