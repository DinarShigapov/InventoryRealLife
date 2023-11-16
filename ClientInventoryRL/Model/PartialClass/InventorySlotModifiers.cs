using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientInventoryRL.Model.PartialClass;

namespace ClientInventoryRL.Model
{
    public partial class InventorySlotModifiers
    {

        public byte[] MainImageStub 
        {
            get 
            {
                if (MainImage != null)
                {
                    return MainImage; 
                }
                else
                {
                    byte[] stabImage = null;

                    switch (TypeModifiresId)
                    {
                        case (int)ModifiresType.Clothes:
                            stabImage = File.ReadAllBytes("C:\\Users\\262023\\source\\repos\\InventoryRealLife\\ClientInventoryRL\\Resources\\IconsUI\\ClothesIcons.png");
                            break;
                    }

                    return stabImage;
                }
            }
        }
    }
}
