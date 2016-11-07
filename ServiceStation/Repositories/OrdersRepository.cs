using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceStation.Data;
using ServiceStation.Models;

namespace ServiceStation.Repositories
{
    public class OrdersRepository //: IOrdersRepository, IDisposable
    {
        private ServiceContext db = new ServiceContext();
        /* private UnitOfWork _unitOfWork;
         public OrdersRepository(IUnitOfWork unitOfWork)
         {
             _unitOfWork = (UnitOfWork)unitOfWork;
         }*/

        public OrdersRepository(ServiceContext db)
        {
            this.db = db;
        }

        public IQueryable<Orders> GetList()
        {
            return db.Orders;
        }

        public Orders Get(int id)
        {
            return db.Orders.Find(id);
        }

        public Orders Create(Orders order)
        {
            db.Orders.Add(order);
            return order;

        }

        public Orders Update(Orders order)
        {
            db.Entry(order).State = EntityState.Modified;
            return order;
        }

        public void Delete(int id)
        {
            Orders order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
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