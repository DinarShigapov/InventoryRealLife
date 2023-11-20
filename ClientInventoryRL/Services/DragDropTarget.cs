using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ClientInventoryRL.Model;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows.Input;

namespace ClientInventoryRL.Services
{
    

    public class DragDropTarget : IDropTarget
    {
        private static IDropTarget _instance;
        public static IDropTarget Instance 
        {
            get 
            {
                if (_instance == null)
                    _instance = new DragDropTarget();
                return _instance;
            }
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        public void DragEnter(IDropInfo dropInfo)
        {
            

        }



        public void DragLeave(IDropInfo dropInfo)
        {

        }

        List<UIElement> element = new List<UIElement>();

        public void DragOver(IDropInfo dropInfo)
        {
            if ((dropInfo.Data as Slot).Item == null)
            {
                return;
            }

            if (dropInfo.TargetItem != null)
            {
                if ((dropInfo.TargetItem as Slot).Item != null)
                {
                    return;
                }
            }

            dropInfo.NotHandled = true;
            dropInfo.Effects = DragDropEffects.Move;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is Slot && dropInfo.TargetItem != null)
            {
                if (dropInfo.Data is Slot )
                {
                    if ((dropInfo.TargetItem as Slot).Item == null && dropInfo.TargetItem as Slot != dropInfo.Data as Slot)
                    {

                        if ((dropInfo.Data as Slot).Item.Weight > (dropInfo.TargetItem as Slot).InventorySlotModifiers.MaxCapacity)
                        {
                            MessageBox.Show("Данный предмет превышает максимальный вес слота");
                            return;
                        }
                        
                        Slot bufferSlot = dropInfo.Data as Slot;
                        (dropInfo.TargetItem as Slot).Item = bufferSlot.Item;
                        (dropInfo.TargetItem as Slot).QuantityItem = bufferSlot.QuantityItem;
                        (dropInfo.Data as Slot).Item = null;
                        (dropInfo.Data as Slot).QuantityItem = null;
                    }
                }
            }
        }



    }
}
