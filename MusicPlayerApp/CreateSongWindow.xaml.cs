using Microsoft.Win32;
using MusicPlayerApp.BLL.Services;
using MusicPlayerApp.DAL.Entities;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CreateSongWindow.xaml
    /// </summary>
    public partial class CreateSongWindow : Window
    {
        private UserServices _userService = new UserServices();
        private SongServices _songService = new SongServices();
        private GenreServices _genreService = new GenreServices();
        public Song? EditedOne { get; set; }

        public CreateSongWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SongIDTextBox.IsEnabled = false;
            UserIDTextBox.IsEnabled = false;
            GenreIdComboBox.ItemsSource = _genreService.GetList();
            GenreIdComboBox.DisplayMemberPath = "Name";
            GenreIdComboBox.SelectedValuePath = "GenreId";

            if (EditedOne == null)
            {
                CreateSongWindowLabel.Content = "Create Song";
                return;
            }
            CreateSongWindowLabel.Content = "Update Song";

            // Edit
            SongIDTextBox.Text = EditedOne.SongId.ToString();
            UserIDTextBox.Text = EditedOne.UserId.ToString();
            TitleTextBox.Text = EditedOne.Title;

            ImageTextBox.Text = EditedOne.Image != null ? GetFileNameFromPath(EditedOne.Image) : string.Empty;
            FilePathTextBox.Text = EditedOne.FilePath != null ? GetFileNameFromPath(EditedOne.FilePath) : string.Empty;
            DurationTextBox.Text = EditedOne.Duration.ToString("HH:mm:ss");
            ReleaseDatePicker.SelectedDate = EditedOne.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue);
            GenreIdComboBox.SelectedValue = EditedOne.GenreId;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Song song = new Song();
            song.UserId = int.Parse(UserIDTextBox.Text);
            song.Title = TitleTextBox.Text;
            song.GenreId = (int)GenreIdComboBox.SelectedValue;
            string imgPath = $"Resources/Images/{ImageTextBox.Text}";
            song.Image = imgPath;
            string audioPath = $"Resources/Songs/{FilePathTextBox.Text}";
            song.FilePath = audioPath;
            song.Duration = TimeOnly.Parse(DurationTextBox.Text);
            song.ReleaseDate = DateOnly.FromDateTime(ReleaseDatePicker.SelectedDate.Value);

            if (EditedOne == null)
            {
                _songService.AddSong(song);
            }
            else
            {
                song.SongId = int.Parse(SongIDTextBox.Text);
                _songService.UpdateSong(song);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // Nếu người dùng chọn file, kiểm tra định dạng file và gán vào ImageTextBox
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                // Kiểm tra nếu file có đuôi .jpg, .jpeg, .png, hoặc .bmp
                string fileExtension = GetFileNameFromPath(filePath).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".bmp")
                {
                    // Gán đường dẫn file vào TextBox
                    ImageTextBox.Text = filePath;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file định dạng ảnh (.jpg, .jpeg, .png, .bmp).", "Định dạng không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void BrowseFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";

            if (openFileDialog.ShowDialog() == true)
            {
                string audioFilePath = openFileDialog.FileName;

                // Kiểm tra nếu file có đuôi .mp3
                if (System.IO.Path.GetExtension(audioFilePath).ToLower() == ".mp3")
                {
                    // Gán tên file có đuôi vào TextBox
                    string fileNameWithExtension = GetFileNameFromPath(audioFilePath);
                    FilePathTextBox.Text = fileNameWithExtension;
                    // Lấy thời lượng của file và gán vào DurationTextBox
                    try
                    {
                        // Sử dụng AudioFileReader của NAudio để đọc file và lấy thời lượng
                        using (var audioFile = new AudioFileReader(audioFilePath))
                        {
                            TimeSpan duration = audioFile.TotalTime;

                            // Hiển thị thời lượng vào TextBox
                            DurationTextBox.Text = duration.ToString("HH:mm:ss");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể đọc thời lượng của file. Lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file định dạng .mp3.", "Định dạng không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string GetFileNameFromPath(string filePath)
        {
            return System.IO.Path.GetFileName(filePath);
        }
    }
}
