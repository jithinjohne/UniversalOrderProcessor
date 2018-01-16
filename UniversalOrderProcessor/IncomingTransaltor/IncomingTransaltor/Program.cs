using Translator;
using Unity;

namespace IncomingTransaltor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = DependencyRegister.RegisterDependecies();
            var translator = container.Resolve<IOrderTranslator>();
            translator.Translate();
        }
    }
}