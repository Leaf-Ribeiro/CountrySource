using CountrySource.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database.Repositores
{
    public abstract class EFRepository<E, T> : BaseDataAccess, IRepository<T>
           where T : class
           where E : DbContext
    {
        protected readonly IUnitOfWorkFactory<E> uofwFactory;

        public EFRepository(IUnitOfWorkFactory<E> uofwFactory) : base()
        {
            if (uofwFactory == null) throw new ArgumentNullException("uofwFactory");

            this.uofwFactory = uofwFactory;

        }

        public virtual T GetById(object id)
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var dbSet = unitOfWork.Context.Set<T>();

                return dbSet.Find(id);
            }
        }


        public virtual IList<T> FindAll()
        {
            return FindAll<T>();
        }

        public virtual IList<P> FindAll<P>() where P : class
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                return unitOfWork.Context.Set<P>().ToList();
            }
        }

        public virtual void Add(T entity)
        {
            this.Add<T>(entity);
        }

        public virtual void Add<EN>(EN entity) where EN : class
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                unitOfWork.Context.Set<EN>().Add(entity);

                unitOfWork.Complete();
            }
        }

        public virtual void Update(T entity)
        {
            this.Update<T>(entity);
        }

        public virtual void Update<EN>(EN entity) where EN : class
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                unitOfWork.Context.Entry<EN>(entity).State = EntityState.Modified;

                unitOfWork.Complete();
            }
        }


        public virtual void Delete(T entity)
        {
            this.Delete<T>(entity);
        }

        public virtual void Delete<EN>(EN entity) where EN : class
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                unitOfWork.Context.Set<EN>().Remove(entity);

                unitOfWork.Complete();
            }
        }
    }
}
