using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSales.API.Interfaces;
using System.Data.Entity;
using  CarSales.Model;
 

namespace CarSales.API
{
    public class VehicleRepository<T> : IVehicleRepository<T> where T : BaseEntity
    {
        private readonly CarSalesDBEntities context;
        private DbSet<T> entities;

        public VehicleRepository(CarSalesDBEntities context)
        {
            this.context = context;
            entities = context.Set<T>();
        }


        public void Add(T obj)
        {

            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(obj);
            context.SaveChanges();
        }

        public void Edit(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public T Get(long Id)
        {
            return entities.SingleOrDefault<T>(x=>x.ID == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Remove(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(obj);
            context.SaveChanges();
        }
    }
}