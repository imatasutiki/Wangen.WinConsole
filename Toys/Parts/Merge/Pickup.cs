using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Pickup
    {
        Play _play;
        Archive _archive;

        IList<House> _houses;

        public Pickup(
            Play play,
            Archive archive)
        {
            this._play = play;
            this._archive = archive;

            this._houses = new List<House>();

            this.Parse();
        }
        public IEnumerable<House> Houses { get { return this._houses; } }

        void Parse()
        {
            var alldirectories = this._play.Visitor.Repository.Directory.RetrieveAllDirectories();

            var q = alldirectories.Where(
                item => ! item.Name.Contains( "__" ) ).OrderByDescending(
                item => item.Name);

            foreach (var item in q)
            {
                var sprint = new Sprint( item );

                this.ProcessSprint(sprint);
            }
        }
        void ProcessSprint(
            Sprint sprint)
        {
            var zero = sprint.Directory.RetrieveDirectory("zero");
            
            var group = zero.RetrieveDirectory(this._archive.File.CurrentDirectory.DirectoryParent.DirectoryParent.Name);

            var current = group.RetrieveDirectory( this._archive.File.CurrentDirectory.DirectoryParent.Name );
            
            var bet = current.RetrieveDirectory(this._archive.File.CurrentDirectory.Name);

            var file = bet.RetrieveFile(this._archive.File.Name);

            var schema = this._play.Toy.Ambit.Wangen.Atoms.OpenSchema(file);

            var house = new House( this._play, sprint, schema);

            this._houses.Add(house);
        }
    }
}
