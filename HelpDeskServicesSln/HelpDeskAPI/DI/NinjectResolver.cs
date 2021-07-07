using HelpDeskDAL;
using HelpDeskDTO;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace HelpDeskAPI.DI
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IConnectionFactory>().To<ConnectionFactory>().InSingletonScope();
            kernel.Bind<IAccountRepository>().To<AccountRepository>().InSingletonScope();
            kernel.Bind<IRepository<DTO_Ticket>>().To<TicketRepository>().InSingletonScope();
            kernel.Bind<IRepository<DTO_User>>().To<UserRepository>().InSingletonScope();
            kernel.Bind<IAddressRepository>().To<AddressRepository>().InSingletonScope();

            return kernel;
        }
    }
}