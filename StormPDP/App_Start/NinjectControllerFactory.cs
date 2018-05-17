using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using StormPDP.Models.Repositories;

namespace StormPDP
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IEmployeeRepository>().To<EfEmployeeRepository>();
            _ninjectKernel.Bind<IDevelopmentPlanRepository>().To<EfDevelopmentPlanRepository>();
            _ninjectKernel.Bind<IManagerRepository>().To<EfManagerRepository>();
            _ninjectKernel.Bind<IReviewRepository>().To<EfReviewRepository>();

                
        }
    }
}