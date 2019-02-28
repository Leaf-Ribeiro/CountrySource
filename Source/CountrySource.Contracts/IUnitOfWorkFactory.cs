using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Contracts
{
    public interface IUnitOfWorkFactory<C> : IUnitOfWorkFactory
    {
        new IUnitOfWork<C> Get(bool withTransaction = false, IsolationLevel? il = null);
    }

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Get(bool withTransaction = false, IsolationLevel? il = null);
    }
}
