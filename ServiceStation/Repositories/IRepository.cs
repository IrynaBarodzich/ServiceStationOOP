using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Repositories
{
    //   interface IRepository<T, in Tid> 
    public interface IRepository<T, Tid>
         where T : class
    {
        IQueryable<T> GetList(); // get all
        T Get(Tid id); // get by id
        T Create(T item);
        void Update(T item);
        void Delete(Tid id);
        void Delete(T item);

    }
}
