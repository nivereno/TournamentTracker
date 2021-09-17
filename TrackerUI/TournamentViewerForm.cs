using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        List<int> rounds = new List<int>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            LoadFormData();

            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            roundDropDown.DataSource = null;
            roundDropDown.DataSource = rounds;
        }
        private void LoadRounds()
        {
            rounds = new List<int>();

            //rounds.Add(1);
            int currRound = 0;
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                //if (matchups.First().MatchupRound > currRound)
                //{
                //    currRound = matchups.First().MatchupRound;
                //    rounds.Add(currRound);
                //}
                currRound += 1;
                rounds.Add(currRound);
            }

            WireUpLists();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
