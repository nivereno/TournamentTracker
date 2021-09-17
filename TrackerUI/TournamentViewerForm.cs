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
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            roundDropDown.DataSource = rounds;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }
        private void LoadRounds()
        {
            //rounds = new BindingList<int>();
            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;
            int i = 1;
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups[i].MatchupRound > currRound)
                {
                    currRound = matchups[i].MatchupRound;
                    rounds.Add(currRound);
                    
                }
                i++;
                //currRound += 1;
                //rounds.Add(currRound);
            }
            LoadMatchups(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void LoadMatchups(int round)
        {
            if (roundDropDown.SelectedItem != null)
            {
                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    //if (matchups.First().MatchupRound == round)
                    //{
                        selectedMatchups.Clear();
                        foreach (MatchupModel m in matchups)
                        {
                            if (m.MatchupRound == round)
                            {
                                selectedMatchups.Add(m);
                            }
                        }
                    //}
                }
                LoadMatchup(selectedMatchups.First());
            }
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeteing != null)
                        {
                            teamOneName.Text = m.Entries[0].TeamCompeteing.TeamName;
                            teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                            teamTwoName.Text = "<bye>";
                            teamTwoScoreValue.Text = "0";
                        }
                        else
                        {
                            teamOneName.Text = "Not Yet Set";
                            teamOneScoreValue.Text = "";
                        }
                    }
                    if (i == 1)
                    {
                        if (m.Entries[1].TeamCompeteing != null)
                        {
                            teamTwoName.Text = m.Entries[1].TeamCompeteing.TeamName;
                            teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                        }
                        else
                        {
                            teamTwoName.Text = "Not Yet Set";
                            teamTwoScoreValue.Text = "";
                        }
                    }
                }
            }
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
        }
    }
}
