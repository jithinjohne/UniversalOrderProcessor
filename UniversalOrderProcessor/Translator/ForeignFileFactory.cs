using System;

namespace Translator
{
    public class ForeignFileFactory : IForeignFileFactory
    {
        private readonly IFile file;

        public ForeignFileFactory(IFile file)
        {
            this.file = file;
        }

        public IForeignFormat CreateForeignFile(string file)
        {
            throw new NotImplementedException();
        }
    }
}