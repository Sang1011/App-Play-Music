using MusicPlayerApp.BLL.Services;
using MusicPlayerApp.DAL.Entities;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace MusicPlayerApp
{
    public partial class DetailWindow : Window
    {
        private SongServices _services = new();
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool isPlaying = false;
        private bool isDragging = false;
        public bool PlaylistUser {  get; set; }
        private Stack<Song> songHistory = new Stack<Song>();

        public User? CurrentUser { get; set; }

        public Song SelectedSong { get; set; }

        public DetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBackButtonState();
            PlayMusic();
            if(PlaylistUser == true)
            {
                BackButton.IsEnabled = false;
                NextButton.IsEnabled = false;
            }
            if(CurrentUser != null && CurrentUser.Role == "Artist")
            {
                BackButton.IsEnabled = false;
                NextButton.IsEnabled = false;
            }
        }

        private void UpdateBackButtonState()
        {
            BackButton.IsEnabled = songHistory.Count > 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mediaPlayer.Stop();  
            mediaPlayer.Close(); 
        }

        public void UpdateSongInfo(Song newSong)
        {
            SelectedSong = newSong;
            DataContext = SelectedSong;
            mediaPlayer.Stop();

            string originalPath = AppDomain.CurrentDomain.BaseDirectory;
            int index = originalPath.IndexOf("bin");
            string newPath = originalPath.Substring(0, index);
            string relativePath = SelectedSong.FilePath;
            string mp3Path = Path.Combine(newPath, relativePath);

            if (File.Exists(mp3Path))
            {
                mediaPlayer.Open(new Uri(mp3Path));
                mediaPlayer.Play();
                isPlaying = true;
            }
            else
            {
                MessageBox.Show("Selected song file does not exist.");
            }
        }


        private void PlayMusic()
        {
            string originalPath = AppDomain.CurrentDomain.BaseDirectory;
            int index = originalPath.IndexOf("bin");
            string newPath = originalPath.Substring(0, index);
            string relativePath = SelectedSong.FilePath;
            string mp3Path = Path.Combine(newPath, relativePath);

            if (File.Exists(mp3Path))
            {
                try
                {
                    if (!isPlaying)
                    {
                        if (mediaPlayer.Source == null)
                        {
                            mediaPlayer.Open(new Uri(mp3Path));
                            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
                        }
                        mediaPlayer.Play();
                        isPlaying = true;
                        PlayButton.Content = "Pause";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing music: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Music file does not exist.");
            }
        }

        private void MediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                ProgressSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                TotalTimeText.Text = FormatTime(mediaPlayer.NaturalDuration.TimeSpan);

                DispatcherTimer timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                timer.Tick += (s, args) =>
                {
                    if (!isDragging)
                    {
                        ProgressSlider.Value = mediaPlayer.Position.TotalSeconds;
                        CurrentTimeText.Text = FormatTime(mediaPlayer.Position);
                    }
                };
                timer.Start();
            }
        }

        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDragging)
            {
                mediaPlayer.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
            }
        }

        private void ProgressSlider_DragStarted(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = true;
        }

        private void ProgressSlider_DragCompleted(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDragging = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
        }

        private string FormatTime(TimeSpan time)
        {
            return $"{(int)time.TotalMinutes}:{time.Seconds:D2}";
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
            {
                PlayMusic();
            }
            else
            {
                mediaPlayer.Pause();
                isPlaying = false;
                PlayButton.Content = "Play";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (songHistory.Count > 0)
            {
                SelectedSong = songHistory.Pop();
                UpdateSongInfo(SelectedSong);
                UpdateBackButtonState();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            songHistory.Push(SelectedSong);
            SelectedSong = _services.GetRandomSong(SelectedSong);
            UpdateSongInfo(SelectedSong);
            UpdateBackButtonState();
        }

        private void FavoriteButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Please login first", "Login Request", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure that you want to add this song to playlists?", "Confirm Request", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                PlaylistShow show = new();
                show.AddOne = true;
                show.SelectedSong = SelectedSong;
                show.CurrentUser = CurrentUser;
                show.ShowDialog();
            }
        }
    }
}
