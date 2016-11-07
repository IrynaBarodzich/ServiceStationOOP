using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceStation.Data;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    public class ClientsRepository //: IClientsRepository, IDisposable
    {

        private ServiceContext db = new ServiceContext();

        /*    private UnitOfWork _unitOfWork;
            public ClientsRepository(IUnitOfWork unitOfWork)
            {
                _unitOfWork = (UnitOfWork)unitOfWork;
            }
            */


        public ClientsRepository(ServiceContext db)
        {
            this.db = db;
        }

        public IQueryable<Clients> GetList()
        {
            return db.Clients;
        }

        public Clients Get(int id)
        {
            return db.Clients.Find(id);
        }

        public Clients Create(Clients client)
        {
            db.Clients.Add(client);
            return client;
        }

        public Clients Update(Clients client)
        {
            db.Entry(client).State = EntityState.Modified;
            return client;

        }

        public void Delete(int id)
        {
            Clients client = db.Clients.Find(id);
            if (client != null)
                db.Clients.Remove(client);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




    }
}