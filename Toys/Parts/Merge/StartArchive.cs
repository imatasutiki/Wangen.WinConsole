using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Pulan.Contracts.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class StartArchive
    {
        Play _play;
        Archive _archive;

        String _filename;
        
        public StartArchive(
            Play play,
            Archive archive )
        {
            this._play = play;
            this._archive = archive;

            this.Parse();
        }
        public String Filename { get { return this._filename; } }
        void Parse()
        {
            var pickup = new Pickup( this._play, this._archive );

            if( ! this._play.Toy.OptionDirectory.HasDirectory( this._archive.File.DirectoryParent.Name ) )
            {
                this._play.Toy.OptionDirectory.CreateDirectory(this._archive.File.DirectoryParent.Name);
            }

            var betdirectory = this._play.Toy.OptionDirectory.RetrieveDirectory(this._archive.File.DirectoryParent.Name);

            this._filename = String.Format( "{0}{1}", 
                betdirectory.Fullname,
                this._archive.File.Name);

            var writer = this._play.Toy.Ambit.Pulan.Atoms.CreateWriter( this._filename );

            writer.WriteAttributeString( "Created", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
            writer.WriteAttributeString( "Archive", this._archive.File.Name );

            writer.WriteStartElement( "Sprints" );

            foreach( var item in pickup.Houses )
            {
                writer.WriteStartElement( "Sprint" );

                writer.WriteAttributeString( "Name", item.Sprint.Directory.Name );
                writer.WriteAttributeString( "FileFullname", item.Schema.File.Fullname );

                this.ProcessContainer( item, writer );

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
        }
        void ProcessContainer(
            House house,
            IWriterConcrete writer)
        {
            writer.WriteStartElement( "Boxes" );

            foreach( var item in house.Rooms )
            {
                writer.WriteStartElement( "Box" );

                writer.WriteAttributeString("Current", item.Box.Current.ToString());

                writer.WriteAttributeString("ID", item.Box.ID.ToString());
                
                writer.WriteAttributeString("DisplayQuantum", item.Box.DisplayQuantum.ToString());
                writer.WriteAttributeString("Quantum", item.Box.Quantum.ToString());

                writer.WriteAttributeString("Factor", item.Box.Factor.ToString());
                writer.WriteAttributeString("DivisorFactor", item.Box.DivisorFactor.ToString());

                writer.WriteAttributeString("Ratio", item.Box.Ratio.ToString());
                writer.WriteAttributeString("Divisor", item.Box.Divisor.ToString());

                writer.WriteAttributeString("Security", item.Box.Security.ToString());

                writer.WriteAttributeString("AveragePrimaryBetGoals", item.Box.AveragePrimaryBetGoals.ToString());
                writer.WriteAttributeString("AverageSecondaryBetGoals", item.Box.AverageSecondaryBetGoals.ToString());

                writer.WriteAttributeString("Distance", item.Box.Distance.ToString());

                writer.WriteAttributeString("Index", item.Box.Index.ToString());
                writer.WriteAttributeString("SuccessUntil", item.Box.SuccessUntil.ToString());

                writer.WriteAttributeString("Boxes", item.Box.Boxes.ToString());
                writer.WriteAttributeString("Warning", item.Box.Warning.ToString());

                writer.WriteAttributeString("Danger", item.Box.Danger.ToString());
                writer.WriteAttributeString("BoxesCount", item.Box.BoxesCount.ToString());
                writer.WriteAttributeString("BoxesComingsoonCount", item.Box.BoxesComingsoonCount.ToString());

                writer.WriteAttributeString("RatioSuccessUntil", item.Box.RatioSuccessUntil.ToString());
                writer.WriteAttributeString("RatioFirst", item.Box.RatioFirst.ToString());

                writer.WriteAttributeString("Kickoff", item.Box.Kickoff.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteAttributeString("TargetPrimaryBet", item.Box.TargetPrimaryBet);
                writer.WriteAttributeString("TargetSecondaryBet", item.Box.TargetSecondaryBet);

                writer.WriteAttributeString("FutureDirectory", item.Box.FutureDirectory);

                writer.WriteAttributeString("Nicename", item.Box.Nicename);

                writer.WriteAttributeString("HomeID", item.Box.HomeID.ToString());
                writer.WriteAttributeString("HomeName", item.Box.HomeName);

                writer.WriteAttributeString("AwayID", item.Box.AwayID.ToString());
                writer.WriteAttributeString("AwayName", item.Box.AwayName);

                writer.WriteAttributeString("EpochsAverage", item.Box.EpochsAverage.ToString());
                writer.WriteAttributeString("LossAverage", item.Box.LossAverage.ToString());

                writer.WriteAttributeString("Voters", item.Box.Voters.ToString());
                writer.WriteAttributeString("AllVoters", item.Box.AllVoters.ToString());

                writer.WriteAttributeString("Trained", item.Box.Trained.ToString());

                writer.WriteAttributeString("CountMatches", item.Box.CountMatches.ToString());
                writer.WriteAttributeString("CountMatchesHome", item.Box.CountMatchesHome.ToString());
                writer.WriteAttributeString("CountMatchesAway", item.Box.CountMatchesAway.ToString());

                writer.WriteAttributeString("CountRepositoryExperiences", item.Box.CountRepositoryExperiences.ToString());
                writer.WriteAttributeString("CountRepositoryExperiencesHome", item.Box.CountRepositoryExperiencesHome.ToString());
                writer.WriteAttributeString("CountRepositoryExperiencesAway", item.Box.CountRepositoryExperiencesAway.ToString());

                writer.WriteAttributeString("SuccessExperiencesPrimaryBet", item.Box.SuccessExperiencesPrimaryBet.ToString());
                writer.WriteAttributeString("SuccessExperiencesSecondaryBet", item.Box.SuccessExperiencesSecondaryBet.ToString());

                writer.WriteAttributeString("SuccessExperiencesHomePrimaryBet", item.Box.SuccessExperiencesHomePrimaryBet.ToString());
                writer.WriteAttributeString("SuccessExperiencesHomeSecondaryBet", item.Box.SuccessExperiencesHomeSecondaryBet.ToString());

                writer.WriteAttributeString("SuccessExperiencesAwayPrimaryBet", item.Box.SuccessExperiencesAwayPrimaryBet.ToString());
                writer.WriteAttributeString("SuccessExperiencesAwaySecondaryBet", item.Box.SuccessExperiencesAwaySecondaryBet.ToString());

                writer.WriteAttributeString("AverageHomeExperiencesTargetGoals", item.Box.AverageHomeExperiencesTargetGoals.ToString());
                writer.WriteAttributeString("AverageAwayExperiencesTargetGoals", item.Box.AverageAwayExperiencesTargetGoals.ToString());

                writer.WriteAttributeString("SuccessMatchesPrimaryBet", item.Box.SuccessMatchesPrimaryBet.ToString());
                writer.WriteAttributeString("SuccessMatchesSecondaryBet", item.Box.SuccessMatchesSecondaryBet.ToString());

                writer.WriteAttributeString("SuccessFirstlyPrimaryBet", item.Box.SuccessFirstlyPrimaryBet.ToString());
                writer.WriteAttributeString("SuccessFirstlySecondaryBet", item.Box.SuccessFirstlySecondaryBet.ToString());

                writer.WriteAttributeString( "HasScore", item.Match.Half.ToString() );

                if( item.Match.Half )
                {
                    writer.WriteAttributeString("FirstHalfHomeGoals", item.Match.FirstHalfHomeGoals.ToString() );
                    writer.WriteAttributeString("FirstHalfAwayGoals", item.Match.FirstHalfAwayGoals.ToString());

                    writer.WriteAttributeString("SecondHalfHomeGoals", item.Match.SecondHalfHomeGoals.ToString());
                    writer.WriteAttributeString("SecondHalfAwayGoals", item.Match.SecondHalfAwayGoals.ToString());

                    writer.WriteAttributeString("Goals", item.Goals.ToString() );
                    writer.WriteAttributeString("SuccessPrimaryBet", item.SuccessPrimaryBet.ToString() );
                    writer.WriteAttributeString("SuccessSecondaryBet", item.SuccessSecondaryBet.ToString());
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
        
    }
}
