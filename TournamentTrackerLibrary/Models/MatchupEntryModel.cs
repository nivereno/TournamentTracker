using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in the matchup.
        /// </summary>
        public int TeamCompetingId{ get; set; }
        public TeamModel TeamCompeteing { get; set; }
        /// <summary>
        /// Represents the score for this team.
        /// </summary>
        public double Score { get; set; }
        public int ParentMatchupId { get; set; }
        /// <summary>
        /// Represents the matchup that this team came from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
