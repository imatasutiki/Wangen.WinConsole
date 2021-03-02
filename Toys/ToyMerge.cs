using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Toys.Atoms.All;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Tisma.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys
{
    class ToyMerge : ToyAbstract<Ambit>
    {
        IOptionMergeConcrete _option;
        IDirectoryConcrete _optiondirectory;

        public ToyMerge(
            Ambit ambit,
            IDirectoryConcrete directory) : base( ambit, "Merge", directory )
        {
            this._option = (IOptionMergeConcrete)ambit.Menu.Selected;

            this.CurrentDirectory.CreateDirectory(this._option.Name);
            this._optiondirectory = this.CurrentDirectory.RetrieveDirectory(this._option.Name);
        }

        public IDirectoryConcrete OptionDirectory { get { return this._optiondirectory; } }

        protected override void innerPlay()
        {
            var sourcedirectory = this.Ambit.Urubamba.Atoms.OpenDirectory(this._option.SourcePath);
            var repository = new Parts.Build.Repository(sourcedirectory);

            var visitor = new Parts.Merge.Visitor( repository );
            
            var play = new Parts.Merge.Play(this, visitor);
            play.Start();
        }
    }
}
