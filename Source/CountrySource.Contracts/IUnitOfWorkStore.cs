using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Contracts
{

    public interface IUnitOfWorkStore
    {
        void Store(string alias, IUnitOfWork unitOfWork);

        void Remove(string alias);

        IUnitOfWork Get(string alias);
    }
}
