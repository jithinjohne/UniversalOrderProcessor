namespace Translator
{
    public interface IForeignFormat : ITranslatable
    {
        object Name { get; }

        void MarkSuccessfullyTranslated();
        void MarkFailedOnTransaltion();
    }
}