using Translator;
using Unity;

namespace IncomingTransaltor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = DependencyRegister.RegisterDependecies();
            container.Resolve<IOrderTranslaor>();
        }
    }
}