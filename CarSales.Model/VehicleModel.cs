//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSales.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleModel : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleModel()
        {
            this.VehicleAdvertisements = new HashSet<VehicleAdvertisement>();
        }
    
      
        public string VehicleModel1 { get; set; }
        public Nullable<int> VehicleMakeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleAdvertisement> VehicleAdvertisements { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
