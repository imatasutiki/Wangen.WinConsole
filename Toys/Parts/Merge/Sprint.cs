using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Sprint
    {
        IDirectoryConcrete _directory;

        public Sprint(
            IDirectoryConcrete directory )
        {
            this._directory = directory;
        }
        public IDirectoryConcrete Directory { get { return this._directory; } }
    }
}
