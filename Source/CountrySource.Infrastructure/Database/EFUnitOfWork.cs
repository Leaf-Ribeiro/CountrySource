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
    public class EFUnitOfWork<T> : IUnitOfWork, IUnitOfWork<T> where T : DbContext
    {
        private T dbContext;
        private DbContextTransaction transaction;
        private int transactionCreatedUsage = 0;

        public EFUnitOfWork(T dbContext, DbContextTransaction transaction = null)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");

            this.dbContext = dbContext;
            this.transaction = transaction;
            this.Usages = 0;
        }

        internal int Usages { get; set; }

        internal event EventHandler Closed;

        public T Context
        {
            get
            {
                return dbContext;
            }
        }

        public void Complete()
        {
            lock (this)
            {
                if (this.Usages == transactionCreatedUsage && transaction != null)
                {
                    transaction.Commit();
                    DisposeTransaction();
                }

                if (transaction == null)
                    dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            lock (this)
            {
                if (transactionCreatedUsage >= this.Usages && transaction != null)
                {
                    transaction.Rollback();
                    DisposeTransaction();
                }

                if (Usages == 1)
                {
                    dbContext.Dispose();

                    if (Closed != null)
                        Closed(this, new EventArgs());
                }

                Usages--;
            }
        }

        internal bool WithTransaction()
        {
            return transaction != null;
        }

        private void DisposeTransaction()
        {
            transaction.Dispose();
            transaction = null;
            transactionCreatedUsage = 0;
        }

        internal void CreateTransactionIfNotExists(IsolationLevel? il)
        {
            if (transaction == null)
            {
                lock (this)
                {
                    if (transaction == null)
                    {
                        transactionCreatedUsage = this.Usages;

                        if (il.HasValue)
                            transaction = dbContext.Database.BeginTransaction(il.Value);
                        else
                            transaction = dbContext.Database.BeginTransaction();
                    }
                }
            }
        }
    }
}
