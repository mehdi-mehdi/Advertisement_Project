using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Advertisement.Common.ServiceContracts;
using Advertisement.DataAccess.DbContext;
using Advertisement.DataAccess.IRepositories;
using Advertisement.DataAccess.Repositories;
using Advertisement.Service;
using Core.Facilities;
using Core.FrameWork.Contract;
using MVC.Controllers;
using StructureMap;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IPersonService>().Use<PersonService>();
                x.For<IPersonRepository>().Use<PersonRepository>();
                x.For<ILogger>().Use<Logger>();
                x.For<IUnitOfWork>().Use<AdvertismentDbContext>();

            });
            ControllerBuilder.Current.SetControllerFactory(new AdvertismentControllerFactory());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
