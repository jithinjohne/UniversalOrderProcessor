namespace Translator
{
    public interface IForeignFileFactory
    {
        IForeignFormat CreateForeignFile(string file);
    }
}