using System.Collections.Generic;
using System.Linq;
using Translator.ForeignOrderFormats;

namespace Translator
{
    /// <summary>
    /// Collection of files pending processing
    /// </summary>
    public class PendingFiles : IPendingFiles
    {
        private readonly IFileSystem fileSystem;
        private readonly IForeignFileFactory foreignFileFactory;

        public PendingFiles(IForeignFileFactory foreignFileFactory, IFileSystem fileSystem)
        {
            this.foreignFileFactory = foreignFileFactory;
            this.fileSystem = fileSystem;
        }

        /// <summary>
        /// Get all <see cref="IForeignFormat"/> files pending processing
        /// </summary>
        /// <returns>Pending <see cref="IForeignFormat"/> files</returns>
        public IEnumerable<IForeignFormat> GetAll()
        {
            var foreignFiles = new List<IForeignFormat>();

            var files = fileSystem.GetPendingFiles();

            foreach (var file in files)
            {
                var foreignFile = foreignFileFactory.CreateForeignFile(file);
                if (foreignFile is Unknown)
                {
                    fileSystem.MarkFileAsUnknown(file);
                }
                else
                {
                    foreignFiles.Add(foreignFile);
                }
            }

            return foreignFiles;
        }
    }
}