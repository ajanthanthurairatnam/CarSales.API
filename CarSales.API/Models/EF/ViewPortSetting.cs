//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSales.API.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewPortSetting
    {
        public int ID { get; set; }
        public Nullable<int> ViewPortID { get; set; }
        public string SettingCode { get; set; }
        public Nullable<int> PageSize { get; set; }
    
        public virtual ViewPort ViewPort { get; set; }
    }
}
