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
    
    public partial class Employees
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary_USD { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Position { get; set; }
        public int Employee_ID { get; set; }
        public int Warehouse_ID { get; set; }
        public int Manager_ID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        public virtual Warehouse Warehouse { get; set; }
    }
}
