using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using DependencyResolver;
using MVCPL.Filters;
using Ninject.Web.Mvc.FilterBindingSyntax;

namespace MVCPL.Infrastracture
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.ConfigurateResolverWeb();
            _kernel.BindFilter<Filters.AuthorizeAttribute>(FilterScope.Controller, null)
                .WhenControllerHas<Filters.AuthorizeAttribute>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}