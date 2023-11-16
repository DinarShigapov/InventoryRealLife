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
        public ItemWindow(Slot slot)
        {
            InitializeComponent();
            contextSlot = slot;
            this.DataContext = App.DB.Item.ToList();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem as Item;
            if (selectedItem == null)
            {
                return;
            }

            contextSlot.Item = selectedItem;

            this.Close();
            
        }
    }
}
