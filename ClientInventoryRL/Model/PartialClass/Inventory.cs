using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ClientInventoryRL.Model.PartialClass;

namespace ClientInventoryRL.Model
{
    public partial class Inventory
    {


       

        public InventorySlotModifiers ClothesModifiers 
        {
            get => InventoryModifiers.FirstOrDefault(
                x => x.InventorySlotModifiers.TypeModifiresId == (int)ModifiresType.Clothes)?.InventorySlotModifiers;
            set 
            {

                SetNewModifires(ModifiresType.Clothes, value);

            }
        }
        public InventorySlotModifiers BackpackModifiers
        {
            get => InventoryModifiers.FirstOrDefault(
                x => x.InventorySlotModifiers.TypeModifiresId == (int)ModifiresType.Backpack)?.InventorySlotModifiers;
            set
            {
                SetNewModifires(ModifiresType.Backpack, value);
            }
        }
        public InventorySlotModifiers BagModifiers
        {
            get => InventoryModifiers.FirstOrDefault(
                x => x.InventorySlotModifiers.TypeModifiresId == (int)ModifiresType.Bag)?.InventorySlotModifiers;
            set
            {
                SetNewModifires(ModifiresType.Bag, value);
            }
        }
        private void SetNewModifires(ModifiresType modifires, InventorySlotModifiers value) 
        {
            if (value != null)
            {
                if (value.TypeModifiresId == (int)modifires)
                {
                    var bagMod = InventoryModifiers.FirstOrDefault(
                    x => x.InventorySlotModifiers.TypeModifiresId == (int)modifires)?.InventorySlotModifiers;

                    if (bagMod == null)
                    {
                        InventoryModifiers.Add(new InventoryModifiers
                        {
                            InventoryId = Id,
                            InventorySlotModifiers = value,
                            WeightStorage = 100,
                        });


                        for (int i = 0; i < value.Slots; i++)
                        {
                            Slot.Add(new Slot
                            {
                                InventoryId = Id,
                                InventorySlotModifiers = value
                            });
                        }

                    }
                    else
                    {
                        bagMod = value;
                    }


                }

            }
        }

        public void RemoveModifires(InventorySlotModifiers modifiers) 
        {
            foreach (var item in Slot.Where(x => x.InventorySlotModifiers == modifiers).ToArray())
            {
                Slot.Remove(item);
            }
            InventoryModifiers.Remove(InventoryModifiers.FirstOrDefault(x => x.InventorySlotModifiers == modifiers));

        }

        public string WarningText 
        {
            get 
            {
                if (IsWarningWeight)
                {
                    return "Memento mori";
                }
                else
                {
                    return "Нормально";
                }
            }
        }

        public bool IsWarningWeight
        {
            get
            {
                if (CurrentWeightInventory > MaxWeightInventory)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ColorWarningWeight
        {
            get 
            {
                if (IsWarningWeight)
                {
                    return "#FFAB1111";
                }
                else
                {
                    return "#E3E1DE";
                }
            }
        }

        public double CurrentSlotInventory
        {
            get
            {
                if (Slot.Count > 0)
                {
                    return MaxSlotInventory - Slot.Where(z => z.Item == null).Count();
                }
                return 0;
            }
        }

        public double MaxSlotInventory
        {
            get
            {
                if (Slot.Count > 0)
                {
                    return Slot.Count();
                }
                return 0;
            }
        }


        public double CurrentWeightInventory
        {
            get 
            {
                if (Slot.Count > 0)
                {
                    return Slot.Where(z => z.Item != null).Sum(x => x.Item.Weight);
                }
                return 0;
            }
        }

        public double MaxWeightInventory
        {
            get
            {
                if (InventoryModifiers.Count > 0)
                {
                    return Math.Round(InventoryModifiers.Sum(z => z.InventorySlotModifiers.MaxCapacity * z.InventorySlotModifiers.Slots), 3);
                }
                return 0;
            }
        }



        public CollectionView CollectionSlots
        {
            get 
            {
                var view = (CollectionView)CollectionViewSource.GetDefaultView(Slot.OrderBy(x => x.InventorySlotModifiers.TypeModifiresId).ToList());
                PropertyGroupDescription groupDescription = new PropertyGroupDescription("InventorySlotModifiers.TypeModifires.Name");
                view.GroupDescriptions.Add(groupDescription);

                return view;
            }
        }

    }
}
