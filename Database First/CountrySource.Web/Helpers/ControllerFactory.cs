using CountrySource.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CountrySource.Web.Helpers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private static Hashtable types = null;

        public ControllerFactory()
        {
        }

        static ControllerFactory()
        {
            types = new Hashtable();

            var itens = (from n in typeof(Controller).Assembly.GetTypes()
                         where n.IsSubclassOf(typeof(Controller))
                         select n).ToList();

            foreach (var item in itens)
            {
                types.Add(item.Name.ToUpper().Replace("CONTROLLER", ""), item);
            }
        }


        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (controllerName != null)
            {
                var item = types[controllerName.ToUpper()] as Type;
                if (item != null)
                    return item;
            }

            return base.GetControllerType(requestContext, controllerName);
        }

        public override void ReleaseController(IController controller)
        {
            IoCWorker.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //TODO: analisar resource not found, não lançar o error
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)IoCWorker.Resolve(controllerType);
        }

    }
}