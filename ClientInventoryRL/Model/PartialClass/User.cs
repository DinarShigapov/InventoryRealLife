using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInventoryRL.Model
{
    public partial class User
    {

        public string FullNameUser
        {
            get 
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
        
        public Inventory CurrentInventory 
        {
            get 
            {
                return Inventory.First();
            }
        } 
    }
}
