namespace Translator
{
    public interface IIncomingFile : ITranslatable
    {
        object Name { get; }

        void MarkSuccessfullyTranslated();
        void MarkFailedOnTransaltion();
    }
}