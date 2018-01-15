using System;
using System.Collections.Generic;

namespace Translator
{
    /// <summary>
    /// Collection of files pending processing
    /// </summary>
    public class PendingFiles : IPendingFiles
    {
        private readonly IForeignFileFactory foreignFileFactory;
        private readonly IDirectory directory;
        private readonly string pendingFilesLocation;

        public PendingFiles(IApplicationSettings applicationSettings, IDirectory directory, IForeignFileFactory foreignFileFactory)
        {
            pendingFilesLocation = applicationSettings.PendingFilesLocation;
            this.directory = directory;
            this.foreignFileFactory = foreignFileFactory;
        }
        /// <summary>
        /// Get all <see cref="IForeignFormat"/> files pending processing
        /// </summary>
        /// <returns>Pending <see cref="IForeignFormat"/> files</returns>
        public IEnumerable<IForeignFormat> GetAll()
        {
            var foreignFiles = new List<IForeignFormat>();
            var files = directory.GetFiles(pendingFilesLocation);
            foreach (var file in files)
            {
                var foreignFile =  foreignFileFactory.CreateForeignFile(file);
                foreignFiles.Add(foreignFile);
            }
            return foreignFiles;
        }
    }
}