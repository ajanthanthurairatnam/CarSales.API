﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarSalesDBEntities : DbContext
    {
        public CarSalesDBEntities()
            : base("name=CarSalesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ConfigSetting> ConfigSettings { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<VehicleAdvertisement> VehicleAdvertisements { get; set; }
        public virtual DbSet<VehicleBody> VehicleBodies { get; set; }
        public virtual DbSet<VehicleFuel> VehicleFuels { get; set; }
        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<VehicleSeller> VehicleSellers { get; set; }
        public virtual DbSet<ViewPort> ViewPorts { get; set; }
        public virtual DbSet<ViewPortSetting> ViewPortSettings { get; set; }
    }
}
