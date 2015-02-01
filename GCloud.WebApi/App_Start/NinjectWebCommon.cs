using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using GCloud.Authorization;
using GCloud.Authorization.Contract;
using GCloud.Common;
using GCloud.Common.Contract;
using GCloud.Core.Breeze;
using GCloud.Core.Contract;
using GCloud.Core.Contract.Breeze;
using GCloud.DataAccess.Contract;
using GCloud.DataAccess.EF;
using GCloud.Models;
using GCloud.WebApi;
using GCloud.WebApi.Common;
using GCloud.WebApi.Common.Contract;
using GCloud.WebApi.Common.Security;
using log4net;
using log4net.Config;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace GCloud.WebApi
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            XmlConfigurator.Configure();
            var loggerForWebApi = LogManager.GetLogger("GCloudWebApi");
            kernel.Bind<ILog>().ToConstant(loggerForWebApi);
            kernel.Bind<DbContext>().ToConstructor(_ => new GCloudContext());
            kernel.Bind<IRepository<Customer>>().To<BaseGenericRepository<Customer>>().InRequestScope();
            kernel.Bind<IGCloudUnitOfWork>().To<GCloudUnitOfWork>().InRequestScope();
            kernel.Bind<IGCloudUnitOfWorkForBreeze>().To<GCloudUnitOfWorkForBreeze>().InRequestScope();
            kernel.Bind<IConnectionStringProvider>().To<ConnectionStringProvider>().InRequestScope();
            kernel.Bind<IAppSettings>().To<AppSettings>().InRequestScope();
            kernel.Bind<IRepository<User>>().To<BaseGenericRepository<User>>().InRequestScope();
            kernel.Bind<IUserSession>().To<UserSession>().InRequestScope();
            kernel.Bind<IGCloudEntitySaveGuard>().To<GCloudEntitySaveGuard>().InRequestScope();
            kernel.Bind<IAuthRuleManager>().To<AuthRuleManager>().InRequestScope();
            kernel.Bind<IRuleFactory>().To<RuleFactory>().InRequestScope();
            kernel.Bind<IActionLogHelper>().To<ActionLogHelper>().InRequestScope();
            kernel.Bind<IActionExceptionHandler>().To<ActionExceptionHandler>().InRequestScope();
            kernel.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>().InRequestScope();
            kernel.Bind<IBreezeSaveManager>().To<BreezeSaveManager>().InRequestScope();
            kernel.Bind<IBreezeServiceFactory>().To<BreezeServiceFactory>().InRequestScope();
            kernel.Bind<IDateTime>().To<DateTimeAdapter>().InRequestScope();
            kernel.Bind<IGCloudRepository>().To<GCloudRepository>().InRequestScope();
            
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}