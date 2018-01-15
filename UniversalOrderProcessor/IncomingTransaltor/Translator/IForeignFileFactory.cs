using Translator.ForeignOrderFormats;

namespace Translator
{
    /// <summary>
    /// Factory to generate <see cref="IForeignFormat"> files
    /// </summary>
    public interface IForeignFileFactory
    {
        /// <summary>
        /// Creates the foreign file.
        /// </summary>
        /// <param name="fileFullPath">The file full path.</param>
        IForeignFormat CreateForeignFile(string fileFullPath);
    }
}