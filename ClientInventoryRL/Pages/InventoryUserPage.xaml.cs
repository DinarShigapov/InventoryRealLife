using ClientInventoryRL.Model;
using ClientInventoryRL.Model.PartialClass;
using ClientInventoryRL.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Resources;
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
            _mediaPlayer.Open(new Uri(@"Resources/Sounds/MouseEnterSound.wav", UriKind.Relative));


            MediaPlayer soundLoaded = new MediaPlayer();
            soundLoaded.Volume = soundLoaded.Volume / 10.0f;
            soundLoaded.Open(new Uri(@"Resources/Sounds/SoundOpenBackpack.wav", UriKind.Relative));
            soundLoaded.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.DB.SaveChangesAsync();
        }

        private void MIAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedSlot = (sender as MenuItem).DataContext as Slot;
            if (selectedSlot == null)
            {
                return;
            }

            _ = new ItemWindow(selectedSlot, App.LoggedUser.CurrentInventory.Slot.ToList()).ShowDialog();
            this.DataContext = null;
            this.DataContext = App.LoggedUser;
        }

        private void MIDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedSlot = (sender as MenuItem).DataContext as Slot;
            if (selectedSlot == null)
            {
                return;
            }
            selectedSlot.Item = null;
            this.DataContext = null;
            this.DataContext = App.LoggedUser;
        }

        private void MIAddModifires_Click(object sender, RoutedEventArgs e)
        {
            var selectedModifires = (sender as MenuItem).Name;
            if (selectedModifires == null)
                return;

            ModifiresWindow modifires = null;

            switch (selectedModifires)
            {
                case "ClothesModifier":
                    modifires = new ModifiresWindow(ModifiresType.Clothes);
                    modifires.ShowDialog();
                    break;
                case "BackpackModifier":
                    modifires = new ModifiresWindow(ModifiresType.Backpack);
                    modifires.ShowDialog();
                    break;
                case "BagModifier":
                    modifires = new ModifiresWindow(ModifiresType.Bag);
                    modifires.ShowDialog();
                    break;
            }

        }

        private void MIDeleteModifires_Click(object sender, RoutedEventArgs e)
        {
            var selectedModifires = (sender as MenuItem).DataContext as InventorySlotModifiers;
            if (selectedModifires == null)
                return;
            App.LoggedUser.CurrentInventory.RemoveModifires(selectedModifires);
        }

        private void FullName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EditProfilePage());
        }

        private void Border_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("C:\\Users\\262023\\source\\repos\\InventoryRealLife\\ClientInventoryRL\\Resources\\HandMoveGrab.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            (sender as Border).Cursor = customCursor;
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
