using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
