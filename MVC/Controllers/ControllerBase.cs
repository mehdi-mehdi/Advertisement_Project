using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Core.FrameWork.Base;
using Core.FrameWork.Contract;
using StructureMap;

namespace MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected ControllerBase()
        {
            Loger = ObjectFactory.GetInstance<ILogger>();
        }
        protected ILogger Loger;
        protected override void OnException(ExceptionContext filterContext)
        {

            Loger.Log(GetLogEntity(filterContext));
            base.OnException(filterContext);
        }

        private LogEntity GetLogEntity(ExceptionContext filterContext)
        {
            var logEntity = new LogEntity
            {
                ClassName = filterContext.RouteData.Values["Controller"] as string,
                MethodName = filterContext.RouteData.Values["Action"] as string,
                InnerException = filterContext.Exception
            };
            return logEntity;
        }
    }
}