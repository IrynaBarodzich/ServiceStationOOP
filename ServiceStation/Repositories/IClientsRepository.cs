using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    interface IClientsRepository : IRepository<Clients, int>
    {

        /*   IQueryable<Clients> GetList();

           Clients Get(int id);

           void Create(Clients client);

           void Update(Clients client);

           void Delete(int id);*/

    }
}
