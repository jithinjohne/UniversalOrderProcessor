namespace Translator.ForeignOrderFormats
{
    public interface ITranslatable
    {
        INativeFormat Translate();
    }
}