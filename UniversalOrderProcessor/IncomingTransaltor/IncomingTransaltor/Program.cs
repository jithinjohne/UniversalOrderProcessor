using Translator;
using Unity;

namespace IncomingTransaltor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = DependencyRegister.RegisterDependencies();
            var translator = container.Resolve<IOrderTranslator>();
            translator.Translate();
        }
    }
}