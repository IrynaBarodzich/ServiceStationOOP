using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    interface ICarsRepository : IRepository<Cars, int>
    {

        /*  IQueryable<Cars> GetList();

          Cars Get(int id);

          void Create(Cars car);

          void Update(Cars car);

          void Delete(int id);*/

    }
}
