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
    
    public partial class InventoryModifiers
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int InventorySlotModifiersId { get; set; }
        public float WeightStorage { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual InventorySlotModifiers InventorySlotModifiers { get; set; }
    }
}
