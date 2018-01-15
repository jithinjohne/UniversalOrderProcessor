namespace Translator
{
    public interface IForeignFormat : ITranslatable
    {
        string Name { get; }

        void MarkSuccessfullyTranslated();

        void MarkFailedOnTransaltion();
    }
}