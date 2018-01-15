namespace Translator
{
    public interface IApplicationSettings
    {
        int ParallelFileProcessLimit { get; }
        string ErrorFilePath { get; }
        string SuccessFilePath { get; }
        string BaseFilePath { get; }
        string PendingFilesLocation { get; }
    }
}