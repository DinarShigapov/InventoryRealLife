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

        public void DragEnter(IDropInfo dropInfo)
        {
            
        }

        public void DragLeave(IDropInfo dropInfo)
        {

        }

        public void DragOver(IDropInfo dropInfo)
        {
            if ((dropInfo.Data as Slot).Item == null)
            {
                return;
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

                        Slot bufferSlot = dropInfo.Data as Slot;
                        (dropInfo.TargetItem as Slot).Item = bufferSlot.Item;
                        (dropInfo.TargetItem as Slot).QuantityItem = bufferSlot.QuantityItem;
                        (dropInfo.Data as Slot).Item = null;
                        (dropInfo.Data as Slot).QuantityItem = null;
                        var vs = dropInfo.VisualTarget as ListBox;
                        vs.Items.Refresh();

                    }

                }
            }
        }



    }
}
