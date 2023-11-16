using ClientInventoryRL.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientInventoryRL.Pages
{
    /// <summary>
    /// Логика взаимодействия для InventoryUserPage.xaml
    /// </summary>
    public partial class InventoryUserPage : Page
    {
        public InventoryUserPage()
        {
            InitializeComponent();
            this.DataContext = App.LoggedUser;
        }

        private MediaPlayer _mediaPlayer;


        async Task PlaySound()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    _mediaPlayer.Play();
                    _mediaPlayer.Position = default(TimeSpan);
                }));
            });
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            PlaySound();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Volume = _mediaPlayer.Volume / 25.0f;
            _mediaPlayer.Open(new Uri(@"C:\Users\dinar\source\repos\WpfApp4\WpfApp4\Resources\MouseEnterSound.wav"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.DB.SaveChanges();
        }

    }
}
