//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientInventoryRL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeModifires : System.ComponentModel.INotifyPropertyChanged
    {
    
    
    #region Implement 
     
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(prop));
    }
     
     #endregion
    
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeModifires()
        {
            this.InventorySlotModifiers = new HashSet<InventorySlotModifiers>();
        }
    
        private int _Id;
        public int Id 
        { 
            get
            {
                return _Id;
            } 
            set
            {
                if(_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
                 
        private string _Name;
        public string Name 
        { 
            get
            {
                return _Name;
            } 
            set
            {
                if(_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
                 
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<InventorySlotModifiers> _InventorySlotModifiers;
        public virtual ICollection<InventorySlotModifiers> InventorySlotModifiers 
        { 
            get
            {
                return _InventorySlotModifiers;
            } 
            set
            {
                if(_InventorySlotModifiers != value)
                {
                    _InventorySlotModifiers = value;
                    OnPropertyChanged("InventorySlotModifiers");
                }
            }
        }
    }
}
