using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Translator
{
    /// <summary>
    /// A register containing all dependencies
    /// </summary>
    public static class DependencyRegister
    {
        
        public static UnityContainer RegisterDependecies()
        {
            var container = new UnityContainer();
            container.RegisterType<IPendingFiles, PendingFiles>();
            container.RegisterType<IForeignFileFactory, ForeignFileFactory>();
            container.RegisterType<IFileSystem, FileSystem>();
            container.RegisterType<IApplicationSettings, ApplicationSettings>();
            container.RegisterType<ILogger, CustomLogger >();
            container.RegisterType<INativeFormat, NativeOrder>();
            container.RegisterType<IOrderTranslaor, OrderTranslator>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            return container;
        }
    }
}
