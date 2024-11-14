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
            CreateSongWindow c = new CreateSongWindow();
            c.CurrentUser = new() {UserId = 3 };
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
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            //// Xác nhận đăng xuất
            //var result = MessageBox.Show("Are you sure you want to log out?",
            //                             "Logout Confirmation",
            //                             MessageBoxButton.YesNo, MessageBoxImage.Question);

            //if (result == MessageBoxResult.Yes)
            //{

            //    // Đóng cửa sổ hiện tại
            //    this.Close();

            //    // Hiển thị màn hình đăng nhập
            //    LoginWindow loginWindow = new LoginWindow();
            //    loginWindow.Show();
            //}
        }

        private void SongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
