using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClientInventoryRL.Model;

namespace ClientInventoryRL
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static InventoryDataBaseEntities DB = new InventoryDataBaseEntities();
        public static User LoggedUser;
    }
}
