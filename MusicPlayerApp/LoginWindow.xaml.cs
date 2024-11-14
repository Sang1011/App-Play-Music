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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserServices _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string? email = EmailTextBox.Text;
            string? password = PasswordTextBox.Text;
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and Password cannot be empty", "Empty field", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User? user = _service.Authenticate(email, password);
            if(user == null)
            {
                MessageBox.Show("Email or password is incorrect", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(user.Role == "Listener")
            {
                MainWindow main = new();
                main.CurrentUser = user;
                main.Show();
                this.Close();
            }
            else
            {
                ArtistWindow artist = new();
                artist.CurrentUser = user;
                artist.Show();
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
