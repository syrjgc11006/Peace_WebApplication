using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Peace.Core;
using Peace.Model;

namespace Peace.Web.App_Start
{
    public class NinjectConfig:DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectConfig(Action<IKernel> addBindings)
        {
            _ninjectKernel =SiteManager.Kernel;
            addBindings(_ninjectKernel);
        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}