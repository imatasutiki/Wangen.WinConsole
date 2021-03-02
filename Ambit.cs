using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Wangen.Contracts;

using Nibiru.Palermo.Contracts;

using Nibiru.Pulan.Contracts;

using Nibiru.Urubamba.Contracts;

using Nibiru.Mozonte.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole
{
    class Ambit
    {
        IWangenFactory _wangen;
        IPalermoFactory _palermo;
        IPulanFactory _pulan;
        IUrubambaFactory _urubamba;
        IMenuConcrete _menu;

        public Ambit(
            IWangenFactory wangen,
            IPalermoFactory palermo,
            IPulanFactory pulan,
            IUrubambaFactory urubamba,
            IMenuConcrete menu )
        {
            this._wangen = wangen;
            this._palermo = palermo;
            this._pulan = pulan;
            this._urubamba = urubamba;
            this._menu = menu;
        }
        public IWangenFactory Wangen { get { return this._wangen; } }
        public IPalermoFactory Palermo { get { return this._palermo; } }
        public IPulanFactory Pulan { get { return this._pulan; } }
        public IUrubambaFactory Urubamba { get { return this._urubamba; } }
        public IMenuConcrete Menu { get { return this._menu; } }

        public void Boot()
        {
            Console.WriteLine( "Type: '{0}'", this._menu.Selected.Type );
            Console.WriteLine( "Name: '{0}'", this._menu.Selected.Name );

            switch( this._menu.Selected.Type )
            {
                case "HelloWorld":

                    this.HelloWorld();
                    break;

                case "Testing":

                    this.Testing();
                    break;

                case "Build":

                    this.Build();
                    break;

                case "Merge":

                    this.Merge();
                    break;

                default:

                    var message = String.Format( "Type: '{0}'", this._menu.Selected.Type );
                    throw new NotSupportedException( message );
            }
        }
        void Merge()
        {
            var directory = this._urubamba.Atoms.OpenDirectory(@"C:\FILES\TEST\wangen");

            var toy = new Toys.ToyMerge(this, directory);
            toy.Play();
        }
        void Build()
        {
            var directory = this._urubamba.Atoms.OpenDirectory(@"C:\FILES\TEST\wangen");

            var toy = new Toys.ToyBuild(this, directory);
            toy.Play();
        }
        void HelloWorld()
        {
            var toy = new Toys.ToyHelloWorld( this );
            toy.Play();
        }
        void Testing()
        {
            var toy = new Toys.ToyTesting(this);
            toy.Play();
        }
    }
}
