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
using ClientInventoryRL.Model;
using ClientInventoryRL.Model.PartialClass;

namespace ClientInventoryRL.Windows
{
    /// <summary>
    /// Логика взаимодействия для ModifiresWindow.xaml
    /// </summary>
    public partial class ModifiresWindow : Window
    {
        public ModifiresWindow(ModifiresType modifires)
        {
            InitializeComponent();

            DataContext = App.DB.InventorySlotModifiers.Where(x => x.TypeModifiresId == (int)modifires).ToList();
        }


        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem as InventorySlotModifiers;
            if (selectedItem == null)
            {
                return;
            }

            switch (selectedItem.TypeModifiresId)
            {
                case 1:
                    App.LoggedUser.CurrentInventory.ClothesModifiers = selectedItem;
                    break;
                case 2:
                    App.LoggedUser.CurrentInventory.BackpackModifiers = selectedItem;
                    break;
                case 3:
                    App.LoggedUser.CurrentInventory.BagModifiers = selectedItem;
                    break;
            }

            this.Close();

        }
    }
}
