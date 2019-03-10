using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Contracts
{
    public interface IUnitOfWork<C> : IUnitOfWork
    {
        C Context { get; }
    }

    public interface IUnitOfWork : IDisposable
    {
        void Complete();
    }
}
