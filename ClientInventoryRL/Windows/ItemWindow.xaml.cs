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
using System.Windows.Shapes;

namespace ClientInventoryRL.Windows
{
    /// <summary>
    /// Логика взаимодействия для ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        Slot contextSlot;
        public ItemWindow(Slot slot, List<Slot> slots)
        {
            InitializeComponent();
            contextSlot = slot;

            var listAccessItem = new List<Item>();
            foreach (var item in App.DB.Item.Where(x => x.UserId == App.LoggedUser.Id).ToList())
            {
                var buffer = App.LoggedUser.CurrentInventory.Slot.Where(x => x.Item != null);
                if (!buffer.Any(x => x.Item.Id == item.Id))
                {
                    listAccessItem.Add(item);
                }
            }


            this.DataContext = listAccessItem.ToList();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem as Item;
            if (selectedItem == null)
            {
                return;
            }

            if (selectedItem.Weight > contextSlot.InventorySlotModifiers.MaxCapacity) 
            {
                MessageBox.Show("Данный предмет превышает максимальный вес слота");
                return;

            }

            contextSlot.Item = selectedItem;

            this.Close();
            
        }
    }
}
