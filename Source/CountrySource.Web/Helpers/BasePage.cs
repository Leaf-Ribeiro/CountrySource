using CountrySource.Contracts;
using CountrySource.Infrastructure;
using System.Web;

namespace CountrySource.Web.Helpers
{
    public class BasePage : System.Web.UI.Page
    {
        public override void ProcessRequest(HttpContext context)
        {
            var uofwFactory = IoCWorker.Resolve<IUnitOfWorkFactory>();

            using (var session = uofwFactory.Get())
            {
                base.ProcessRequest(context);
            }
        }
    }
}