using Unity;
using Unity.Lifetime;

namespace Translator
{
    /// <summary>
    /// A register containing all dependencies
    /// </summary>
    public static class DependencyRegister
    {
        /// <summary>
        /// Registers the dependencies
        /// </summary>
        /// <returns><see cref="UnityContainer"/> with all registrations</returns>
        public static UnityContainer RegisterDependecies()
        {
            var container = new UnityContainer();
            container.RegisterType<IPendingFiles, PendingFiles>();
            container.RegisterType<IForeignFileFactory, ForeignFileFactory>();
            container.RegisterType<IFileSystem, FileSystem>();
            container.RegisterType<IApplicationSettings, ApplicationSettings>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILogger, CustomLogger>();
            container.RegisterType<INativeFormat, NativeOrder>();
            container.RegisterType<IOrderTranslator, OrderTranslator>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            return container;
        }
    }
}