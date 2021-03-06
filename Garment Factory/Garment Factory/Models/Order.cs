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
    
    public partial class Order
    {
        public int Order_ID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public int Product_ID { get; set; }
        public int Client_ID { get; set; }
        public string Coupon { get; set; }
        public Nullable<int> DeliveryInfo_ID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual DeliveryInfo DeliveryInfo { get; set; }
        public virtual Product Product { get; set; }
    }
}
