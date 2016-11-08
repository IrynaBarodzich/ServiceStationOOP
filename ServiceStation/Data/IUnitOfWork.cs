using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStation.Repositories;

namespace ServiceStation.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T, Tid> RepositoryFor<T, Tid>() where T : class;
        void Commit();
    }
}
