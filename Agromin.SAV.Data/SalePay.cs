//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agromin.SAV.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalePay
    {
        public int SalePayId { get; set; }
        public Nullable<decimal> AmontMissing { get; set; }
        public Nullable<decimal> AmontPay { get; set; }
        public Nullable<System.DateTime> Create_date { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public Nullable<int> SaleId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Sale Sale { get; set; }
        public virtual User User { get; set; }
    }
}
