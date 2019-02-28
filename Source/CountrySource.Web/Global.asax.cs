using CountrySource.Contracts;
using CountrySource.Infrastructure;
using Sicongerp.Web.Helpers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using CountrySource.Web.Helpers;

namespace CountrySource.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = IoCWorker.Container;

            Installer(container);

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataAnnotationsModelValidatorProvider
            .AddImplicitRequiredAttributeForValueTypes = false;

            //filters
            GlobalFilters.Filters.Add(new UnitOfWorkAttribute(IoCWorker.Resolve<IUnitOfWorkFactory>()));
        }

        void Global_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (HttpContext.Current.CurrentHandler is MvcHandler)
            {
                Response.Cache.SetExpires(DateTimeOffset.Now.LocalDateTime.AddYears(-100));
                Response.Cache.SetValidUntilExpires(false);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoServerCaching();
                Response.Cache.SetNoStore();
            }
        }

        private void Installer(Container container)
        {

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        }
    }
}
