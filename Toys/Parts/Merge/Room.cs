using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nibiru.Wangen.Contracts.Atoms.All;

using Nibiru.Minsk.Atoms.All;

namespace Nibiru.Wangen.WinConsole.Toys.Parts.Merge
{
    class Room
    {
        House _house;
        IBoxConcrete _box;

        EntityMatch _match;

        Int32 _goals;
        Boolean _successprimarybet;
        Boolean _successsecondarybet;

        public Room(
            House house,
            IBoxConcrete box )
        {
            this._house = house;
            this._box = box;

            this.Parse();
        }
        public Int32 Goals { get { return this._goals; } }
        public Boolean SuccessPrimaryBet { get { return this._successprimarybet; } }
        public Boolean SuccessSecondaryBet { get { return this._successsecondarybet; } }

        void Parse()
        {
            this._match = this._house.Play.ReaderMatch.RetrieveMatchByID( this._box.ID );

            if( this._match.Half )
            {
                switch (this._house.Schema.Bet)
                {
                    case "Goals15Yes":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.FirstHalfAwayGoals.Value
                            + this._match.SecondHalfHomeGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals > 1.5) this._successprimarybet = true;
                        if (this._goals > 2.5) this._successsecondarybet = true;

                        break;

                    case "Goals35Non":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.FirstHalfAwayGoals.Value
                            + this._match.SecondHalfHomeGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals < 3.5) this._successprimarybet = true;
                        if (this._goals < 2.5) this._successsecondarybet = true;

                        break;

                    case "HomeGoals05Yes":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.SecondHalfHomeGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "HomeGoals25Non":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.SecondHalfHomeGoals.Value;

                        if (this._goals < 2.5) this._successprimarybet = true;
                        if (this._goals < 1.5) this._successsecondarybet = true;

                        break;

                    case "AwayGoals05Yes":

                        this._goals = this._match.FirstHalfAwayGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "AwayGoals25Non":

                        this._goals = this._match.FirstHalfAwayGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals < 2.5) this._successprimarybet = true;
                        if (this._goals < 1.5) this._successsecondarybet = true;

                        break;

                    case "FirstHalfGoals05Yes":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.FirstHalfAwayGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "FirstHalfGoals25Non":

                        this._goals = this._match.FirstHalfHomeGoals.Value + this._match.FirstHalfAwayGoals.Value;

                        if (this._goals < 2.5) this._successprimarybet = true;
                        if (this._goals < 1.5) this._successsecondarybet = true;

                        break;

                    case "SecondHalfGoals05Yes":

                        this._goals = this._match.SecondHalfHomeGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "SecondHalfGoals25Non":

                        this._goals = this._match.SecondHalfHomeGoals.Value + this._match.SecondHalfAwayGoals.Value;

                        if (this._goals < 2.5) this._successprimarybet = true;
                        if (this._goals < 1.5) this._successsecondarybet = true;

                        break;

                    case "HomeFirstHalfGoals05Yes":

                        this._goals = this._match.FirstHalfHomeGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "HomeFirstHalfGoals15Non":

                        this._goals = this._match.FirstHalfHomeGoals.Value;

                        if (this._goals < 1.5) this._successprimarybet = true;
                        if (this._goals < 0.5) this._successsecondarybet = true;

                        break;

                    case "AwayFirstHalfGoals05Yes":

                        this._goals = this._match.FirstHalfAwayGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "AwayFirstHalfGoals15Non":

                        this._goals = this._match.FirstHalfAwayGoals.Value;

                        if (this._goals < 1.5) this._successprimarybet = true;
                        if (this._goals < 0.5) this._successsecondarybet = true;

                        break;

                    case "HomeSecondHalfGoals05Yes":

                        this._goals = this._match.SecondHalfHomeGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "HomeSecondHalfGoals15Non":

                        this._goals = this._match.SecondHalfHomeGoals.Value;

                        if (this._goals < 1.5) this._successprimarybet = true;
                        if (this._goals < 0.5) this._successsecondarybet = true;

                        break;

                    case "AwaySecondHalfGoals05Yes":

                        this._goals = this._match.SecondHalfAwayGoals.Value;

                        if (this._goals > 0.5) this._successprimarybet = true;
                        if (this._goals > 1.5) this._successsecondarybet = true;

                        break;

                    case "AwaySecondHalfGoals15Non":

                        this._goals = this._match.SecondHalfAwayGoals.Value;

                        if (this._goals < 1.5) this._successprimarybet = true;
                        if (this._goals < 0.5) this._successsecondarybet = true;

                        break;

                    default:

                        var message = String.Format( "Bet: '{0}'", this._house.Schema.Bet );
                        throw new NotSupportedException( message );
                }
            }
        }
        public House House { get { return this._house; } }
        public IBoxConcrete Box { get { return this._box; } }
        public EntityMatch Match { get { return this._match; } }
    }
}
