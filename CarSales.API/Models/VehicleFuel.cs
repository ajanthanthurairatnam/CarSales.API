//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSales.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleFuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleFuel()
        {
            this.VehicleAdvertisements = new HashSet<VehicleAdvertisement>();
        }
    
        public int ID { get; set; }
        public string FuelType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleAdvertisement> VehicleAdvertisements { get; set; }
    }
}
