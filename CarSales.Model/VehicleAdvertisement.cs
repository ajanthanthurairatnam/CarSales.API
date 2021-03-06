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
    
    public partial class VehicleAdvertisement : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleAdvertisement()
        {
            this.VehicleSellers = new HashSet<VehicleSeller>();
        }
    
        public int Reference_ID { get; set; }
        public string Title { get; set; }
        public string Reference_No { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BodyType { get; set; }
        public Nullable<int> EngineCapacity { get; set; }
        public Nullable<decimal> AudoMeter { get; set; }
        public Nullable<int> Fuel { get; set; }
        public string Description { get; set; }
        public string Feature { get; set; }
        public string Spects { get; set; }
        public Nullable<int> Make { get; set; }
        public Nullable<int> Model { get; set; }
        public bool IsFeatured { get; set; }
        public string Transmission { get; set; }
    
        public virtual VehicleBody VehicleBody { get; set; }
        public virtual VehicleFuel VehicleFuel { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleSeller> VehicleSellers { get; set; }
    }
}
