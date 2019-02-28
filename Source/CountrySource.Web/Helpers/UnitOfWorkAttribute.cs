using CountrySource.Contracts;
using System;
using System.Web.Mvc;

namespace Sicongerp.Web.Helpers
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        private IUnitOfWorkFactory uofwFactory;

        public UnitOfWorkAttribute(IUnitOfWorkFactory uofwFactory)
        {
            if (uofwFactory == null) throw new ArgumentNullException("uofwFactory");

            this.uofwFactory = uofwFactory;
        }        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            filterContext.HttpContext.Items.Add("SessionKey", uofwFactory.Get());

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try {
                if (filterContext.IsChildAction)
                    return;

                var unitOfWork = (IUnitOfWork)filterContext.HttpContext.Items["SessionKey"];

                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                //Do nothing
            }
        }
    } 
}