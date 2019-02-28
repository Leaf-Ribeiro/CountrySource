using CountrySource.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application
{
    public class AppService<R, E> where R : IRepository<E> where E : class, new()
    {
        protected readonly R repository;
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;

        public AppService(IUnitOfWorkFactory unitOfWorkFactory, R repository)
        {
            if (repository == null)

                this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException("unitOfWorkFactory");
            this.repository = repository;
        }

        public virtual void Create(E entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            repository.Add(entity);
        }

        public virtual void Delete(E entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            repository.Delete(entity);
        }

        public virtual E GetById(object id)
        {
            return repository.GetById(id);
        }

        public virtual IList<E> FindAll()
        {
            return repository.FindAll();
        }

    }
}
