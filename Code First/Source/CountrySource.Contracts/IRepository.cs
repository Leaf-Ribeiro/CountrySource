using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        IList<T> FindAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
