using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.API.Interfaces
{
    public interface IVehicleRepository<T>
    {
        void Add(T obj);
        void Edit(T obj);
        void Remove(T obj);
        IEnumerable<T> GetAll();
        T Get(long id);
    }
}
