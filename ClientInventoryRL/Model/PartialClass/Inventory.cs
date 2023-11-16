﻿using System;
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



        private void AddSingltonModifires(InventorySlotModifiers value) 
        {
            if (value != null)
            {
                if (InventoryModifiers.All(x => x.InventorySlotModifiers.TypeModifiresId != value.TypeModifiresId))
                {
                    InventoryModifiers.Add(new InventoryModifiers
                    {
                        InventoryId = Id,
                        InventorySlotModifiers = value
                    });
                }
            }
        }
    
        public InventorySlotModifiers ClothesModifiers 
        {
            get => InventoryModifiers.FirstOrDefault(
                x => x.InventorySlotModifiers.TypeModifiresId == (int)ModifiresType.Clothes).InventorySlotModifiers;
            set 
            {
                AddSingltonModifires(value);
            }
        }

        public InventorySlotModifiers BackpackModifiers
        {
            get => InventoryModifiers.FirstOrDefault(
                x => x.InventorySlotModifiers.TypeModifiresId == (int)ModifiresType.Backpack).InventorySlotModifiers;
            set
            {
                AddSingltonModifires(value);
            }
        }

        public InventorySlotModifiers BagModifiers
        {
            get => null;
            set
            {
                AddSingltonModifires(value);
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
                    return InventoryModifiers.Sum(z => z.InventorySlotModifiers.MaxCapacity);
                }
                return 0;
            }
        }

        public CollectionView CollectionSlots
        {
            get 
            {
                var view = (CollectionView)CollectionViewSource.GetDefaultView(Slot.ToList());
                PropertyGroupDescription groupDescription = new PropertyGroupDescription("InventorySlotModifiers.TypeModifires.Name");
                view.GroupDescriptions.Add(groupDescription);

                return view;
            }
        }

    }
}