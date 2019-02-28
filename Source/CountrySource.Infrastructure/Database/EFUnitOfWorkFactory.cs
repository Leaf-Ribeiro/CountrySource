using CountrySource.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database
{
    public class EFUnitOfWorkFactory<T> : IUnitOfWorkFactory<T> where T : DbContext
    {
        private string alias = "SESSION.EF.UNITOFWORK";
        private readonly IUnitOfWorkStore store;

        public EFUnitOfWorkFactory(IUnitOfWorkStore store)
        {
            if (store == null) throw new ArgumentNullException("store");

            this.store = store;
        }

        public void Dispose()
        {

        }

        public IUnitOfWork<T> Get(bool withTransaction = false, IsolationLevel? il = null)
        {
            var unitOfWork = store.Get(alias) as EFUnitOfWork<T>;
            if (unitOfWork == null)
            {
                lock (this)
                {
                    unitOfWork = store.Get(alias) as EFUnitOfWork<T>;
                    if (unitOfWork == null)
                    {
                        unitOfWork = new EFUnitOfWork<T>((T)Activator.CreateInstance<T>(), null);
                        unitOfWork.Closed += unitOfWork_Closed;
                        store.Store(alias, unitOfWork);
                    }
                }
            }

            lock (unitOfWork)
                unitOfWork.Usages++;

            if (withTransaction)
                unitOfWork.CreateTransactionIfNotExists(il);

            return unitOfWork;
        }

        void unitOfWork_Closed(object sender, EventArgs e)
        {
            store.Remove(alias);
        }

        IUnitOfWork IUnitOfWorkFactory.Get(bool withTransaction, IsolationLevel? il)
        {
            return Get(withTransaction, il);
        }
    }
}
