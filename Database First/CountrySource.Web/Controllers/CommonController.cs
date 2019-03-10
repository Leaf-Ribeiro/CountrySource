using CountrySource.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class CommonController : Controller
    {
        public CommonController()
        {

        }

        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    string cultureName = RouteData.Values["culture"] as string;

        //    if (cultureName == null)
        //        cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

        //    cultureName = CultureHelper.GetImplementedCulture(cultureName); // Veja mais abaixo na resposta

        //    if (RouteData.Values["culture"] as string != cultureName)
        //    {
        //        // Força uma cultura válida na URL
        //        RouteData.Values["culture"] = cultureName.ToLowerInvariant();
        //        Response.RedirectToRoute(RouteData.Values);
        //    }

        //    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
        //    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        //    return base.BeginExecuteCore(callback, state);
        //}
    }
}