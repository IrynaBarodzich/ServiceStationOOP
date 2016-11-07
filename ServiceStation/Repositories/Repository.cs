using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceStation.Data;

namespace ServiceStation.Repositories
{
    public class Repository<T, Tid> : IRepository<T, Tid> where T : class
    {
        //          private ServiceContext _db = new ServiceContext();

        //    private DbSet<T> entities;
        /* private UnitOfWork _unitOfWork;
         public CarsRepository(IUnitOfWork unitOfWork)
         {
             _unitOfWork = (UnitOfWork)unitOfWork;
         }
         */

        private ServiceContext _db;
        private DbSet<T> _dbSet;

        public Repository(ServiceContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        

        protected ServiceContext db { get; set; }

        public virtual IQueryable<T> GetList()
        {
            IQueryable<T> query = _dbSet;
            return query;
        }

        public virtual T Get(Tid id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Create(T item)
        {
            _dbSet.Add(item);
            return item;
        }

        public virtual void Update(T item)
        {
            

            _dbSet.Attach(item);
            _db.Entry(item).State = EntityState.Modified;


        }

        public virtual void Delete(Tid id)
        {
            T item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }

        }

        public virtual void Delete(T item)
        {
            if (item != null)
            {
                _dbSet.Remove(item);
            }

        }


    }
}