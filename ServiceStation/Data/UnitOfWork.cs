using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceStation.Repositories;

namespace ServiceStation.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ServiceContext _db;

        public UnitOfWork(ServiceContext db)
        {
            _db = db;
        }

        public IRepository<T, Tid> RepositoryFor<T, Tid>() where T : class
        {
            return new Repository<T,Tid>(_db);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }


        /*  private ServiceContext db = new ServiceContext();
         public UnitOfWork(ServiceContext _db)
          {

              db = _db;
          }
          public void Save()
          {
              db.SaveChanges();
          }

               private ClientsRepository clientsRepository;
               private CarsRepository carsRepository;
               private OrdersRepository ordersRepository;

               public ClientsRepository Clients
               {
                   get
                   {
                       if (clientsRepository == null)
                           clientsRepository = new ClientsRepository(db);
                       return clientsRepository;
                   }
               }

               public CarsRepository Cars
               {
                   get
                   {
                       if (carsRepository == null)
                           carsRepository = new CarsRepository(db);
                       return carsRepository;
                   }
               }

               public OrdersRepository Orders
               {
                   get
                   {
                       if (ordersRepository == null)
                           ordersRepository = new OrdersRepository(db);
                       return ordersRepository;
                   }
               }
          */

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}