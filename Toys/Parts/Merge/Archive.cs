using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Archive
    {
        IFileConcrete _file;
        public Archive(
            IFileConcrete file)
        {
            this._file = file;
        }
        public IFileConcrete File { get { return this._file; } }
    }
}
