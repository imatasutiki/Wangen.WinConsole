using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Urubamba.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Visitor
    {
        Build.Repository _repository;
        IList<Archive> _archives;

        public Visitor(
            Build.Repository repository )
        {
            this._repository = repository;
            this._archives = new List<Archive>();

            this.Parse();
        }
        public Build.Repository Repository { get { return this._repository; } }
        public IEnumerable<Archive> Archives { get { return this._archives; } }
        void Parse()
        {
            var alldirectories = this._repository.Directory.RetrieveAllDirectories();

            var q = alldirectories.Where(
                item => ! item.Name.Contains( "__" ) ).OrderByDescending(
                item => item.Name);

            var first = q.First();

            var zero = first.RetrieveDirectory( "zero" );

            this.ProcessZero( zero );
        }

        void ProcessZero(
            IDirectoryConcrete directory)
        {
            var alldirectories = directory.RetrieveAllDirectories();

            foreach( var item in alldirectories )
            {
                this.ProcessGroup( item );
            }
        }
        void ProcessGroup(
            IDirectoryConcrete directory)
        {
            var alldirectories = directory.RetrieveAllDirectories();

            var q = alldirectories.OrderByDescending(
                item => item.Name);

            var first = q.First();

            this.ProcessCurrent( first );
        }
        void ProcessCurrent(
            IDirectoryConcrete directory)
        {
            var alldirectories = directory.RetrieveAllDirectories();

            foreach( var item in alldirectories )
            {
                this.ProcessBet( item );
            }
        }
        void ProcessBet(
            IDirectoryConcrete directory)
        {
            var allfiles = directory.RetrieveAllFiles("*.xml", System.IO.SearchOption.TopDirectoryOnly);

            foreach (var item in allfiles)
            {
                var archive = new Archive(item);

                this._archives.Add(archive);
            }
        }
    }
}
