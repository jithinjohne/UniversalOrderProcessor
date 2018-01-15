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
        private readonly IOperatingSystem operatingSystem;
        private readonly IForeignFileFactory foreignFileFactory;
        private readonly IDirectory directory;
        private readonly string pendingFilesLocation;

        public PendingFiles(IApplicationSettings applicationSettings, IDirectory directory, IForeignFileFactory foreignFileFactory, IOperatingSystem operatingSystem)
        {
            pendingFilesLocation = applicationSettings.PendingFilesLocation;
            this.directory = directory;
            this.foreignFileFactory = foreignFileFactory;
            this.operatingSystem = operatingSystem;
        }

        /// <summary>
        /// Get all <see cref="IForeignFormat"/> files pending processing
        /// </summary>
        /// <returns>Pending <see cref="IForeignFormat"/> files</returns>
        public IEnumerable<IForeignFormat> GetAll()
        {
            var foreignFiles = new List<IForeignFormat>();
            var files = directory.GetFiles(pendingFilesLocation).Take(10);
            foreach (var file in files)
            {
                var foreignFile = foreignFileFactory.CreateForeignFile(file);
                if (foreignFile is Unknown)
                {
                    operatingSystem.MarkFileAsUnknown(file);
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