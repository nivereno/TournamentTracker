using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        public TeamModel Winner { get; set; }
        public int MatchupRound { get; set; }
        public string DisplayName
        {
            get
            {
                string output = "";

                foreach (MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeteing != null)
                    {
                        if (output.Length == 0 && me.TeamCompeteing != null)
                        {
                            output = me.TeamCompeteing.TeamName;
                        }
                        else if (me.TeamCompeteing != null)
                        {
                            output += $" vs. { me.TeamCompeteing.TeamName }";
                        }
                    }
                    else
                    {
                        output = "Matchup not yet determined";
                        break;
                    }
                }

                return output;
            }
        }
    }
}
