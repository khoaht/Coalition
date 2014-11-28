[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CoalitionLoyalty.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CoalitionLoyalty.App_Start.NinjectWebCommon), "Stop")]

namespace CoalitionLoyalty.App_Start
{
    using System;
    using System.Web;
    using CL.Infrastructure;
    using CL.Infrastructure.Services;
    using Domain.Entity;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            #region Service
            kernel.Bind<ITransactionService>().To<TransactionService>()
                .InSingletonScope();
            #endregion

            #region Service
            kernel.Bind<ITransactionService>().To<TransactionService>()
                .InSingletonScope();
            #endregion

            #region Service
            kernel.Bind<ITransactionService>().To<TransactionService>()
                .InSingletonScope();
            #endregion

            #region Repositories

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind(typeof(IRepository<User>)).To(typeof(Repository<User>));
            kernel.Bind(typeof(IRepository<Role>)).To(typeof(Repository<Role>));
            kernel.Bind(typeof(IRepository<Transaction>)).To(typeof(Repository<Transaction>));
            kernel.Bind(typeof(IRepository<Client>)).To(typeof(Repository<Client>));
            kernel.Bind(typeof(IRepository<Card>)).To(typeof(Repository<Card>));
            kernel.Bind(typeof(IRepository<Company>)).To(typeof(Repository<Company>));
            #endregion
        }
    }
}
