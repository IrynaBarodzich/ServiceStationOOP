using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    interface IOrdersRepository : IRepository<Orders, int>
    {
        /* IQueryable<Orders> GetList();

         Orders Get(int id);

         void Create(Orders orders);

         void Update(Orders orders);

         void Delete(int id);*/

    }
}
