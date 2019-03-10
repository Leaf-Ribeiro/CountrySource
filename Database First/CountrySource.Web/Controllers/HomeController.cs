using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class HomeController : CommonController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}