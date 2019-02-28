using CountrySource.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CountrySource.Infrastructure.Database
{
    public class WebUnitOfWorkStore : IUnitOfWorkStore
    {

        public WebUnitOfWorkStore()
        {

        }

        public void Store(string alias, IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException("alias");

            var context = HttpContext.Current;
            if (context != null)
            {
                context.Items[alias] = unitOfWork;
            }
            else
            {
                CallContext.SetData(alias, unitOfWork);
            }
        }

        public void Remove(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException("alias");

            var context = HttpContext.Current;
            if (context != null)
            {
                context.Items.Remove(alias);
            }
            else
            {
                CallContext.SetData(alias, null);
            }
        }

        public IUnitOfWork Get(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException("alias");

            var context = HttpContext.Current;
            if (context != null)
            {
                return context.Items[alias] as IUnitOfWork;
            }
            else
            {
                return CallContext.GetData(alias) as IUnitOfWork;
            }
        }
    }
}
