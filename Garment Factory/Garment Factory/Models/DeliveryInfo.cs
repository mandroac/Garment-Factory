//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garment_Factory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryInfo()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int DeliveryInfo_ID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int Order_ID { get; set; }
        public Nullable<System.DateTime> DispatchDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string TrackingNumber { get; set; }
        public double DeliveryPrice { get; set; }
        public bool Received { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}