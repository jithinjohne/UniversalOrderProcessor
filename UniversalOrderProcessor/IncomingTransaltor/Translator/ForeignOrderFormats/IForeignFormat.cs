namespace Translator.ForeignOrderFormats
{
    public interface IForeignFormat : ITranslatable
    {
        string Name { get; }

        void MarkSuccessfullyTranslated();

        void MarkFailedOnTranslation();
    }
}