using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

using Nibiru.Palermo.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Play
    {
        ToyMerge _toy;
        Visitor _visitor;

        ITableReaderMatch _readermatch;

        public Play(
            ToyMerge toy,
            Visitor visitor)
        {
            this._toy = toy;
            this._visitor = visitor;

            this._readermatch = this._toy.Ambit.Palermo.Atoms.CreateTableReaderMatch();
        }
        public ToyMerge Toy { get { return this._toy; } }
        public Visitor Visitor { get { return this._visitor; } }
        public ITableReaderMatch ReaderMatch { get { return this._readermatch; } }
        public void Start()
        {
            var allarchives = this._visitor.Archives;

            var count = allarchives.Count();
            var i = 0;

            foreach( var item in allarchives )
            {
                Console.WriteLine( "{0} / {1}", ++i, count );
                Console.WriteLine( item.File.Name );

                var start = new StartArchive( this, item );

                Console.WriteLine( start.Filename );
            }
        }
    }
}
