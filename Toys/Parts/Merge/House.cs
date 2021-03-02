using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Wangen.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class House
    {
        Play _play;
        Sprint _sprint;
        ISchemaConcrete _schema;

        IList<Room> _rooms;

        public House(
            Play play,
            Sprint sprint,
            ISchemaConcrete schema )
        {
            this._play = play;
            this._sprint = sprint;
            this._schema = schema;

            this._rooms = new List<Room>();

            this.Parse();
        }
        void Parse()
        {
            foreach( var item in this._schema.Boxes )
            {
                var room = new Room( this, item );
                this._rooms.Add( room );
            }
        }
        public Play Play { get { return this._play; } }
        public Sprint Sprint { get { return this._sprint; } }
        public ISchemaConcrete Schema { get { return this._schema; } }
        public IEnumerable<Room> Rooms { get { return this._rooms; } }
    }
}
