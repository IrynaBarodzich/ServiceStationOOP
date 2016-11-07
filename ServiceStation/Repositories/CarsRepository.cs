using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceStation.Data;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    public class CarsRepository //: ICarsRepository, IDisposable
    {
        private ServiceContext db = new ServiceContext();
        /* private UnitOfWork _unitOfWork;
         public CarsRepository(IUnitOfWork unitOfWork)
         {
             _unitOfWork = (UnitOfWork)unitOfWork;
         }
         */
        public CarsRepository(ServiceContext db)
        {
            this.db = db;
        }

        public IQueryable<Cars> GetList()
        {
            return db.Cars;
        }

        public Cars Get(int id)
        {
            return db.Cars.Find(id);
        }

        public Cars Create(Cars car)
        {
            db.Cars.Add(car);
            return car;
        }

        public Cars Update(Cars car)
        {
            db.Entry(car).State = EntityState.Modified;
            return car;
        }

        public void Delete(int id)
        {
            Cars car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
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