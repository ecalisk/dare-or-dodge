/* - - - - * 
 April 2021, OOP Project 3
 * - - - - *
 Team: noble rubber duckies
 * - - - - * 
 Members:
 Emirhan Caliskan (56140)
 Nattawat Srisuriyaprateep (55499)
 * - - - - *
 Simple dice-based luck game.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dare_or_dodge
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();         
        }

        //EXCEPTION HANDLING + PLAYER COUNT AND END SCORE REGISTERING
        private void buttonVerify_Click(object sender, EventArgs e)
        {
            //is playerCount integer? AND is endScore integer?
            if (int.TryParse(playerCountTBox.Text, out _) && int.TryParse(endScoreTBox.Text, out _)) 
            {
                int playerCount = int.Parse(playerCountTBox.Text);
                int endScore = int.Parse(endScoreTBox.Text);

                //is playerCount more than 4 OR less than 2 OR empty
                if (playerCount > 4 || playerCount < 2 || playerCountTBox.Text == "")
                {
                    errorLabel.Text = "Player number should be between 2 and 4";
                }
                //is endScore more than 1000 OR less than 10 OR empty
                else if (endScore > 1000 || endScore < 10 || endScoreTBox.Text == "")
                {
                    errorLabel.Text = "End score has to be between 10 and 1000";
                }
                else
                {
                    //enable player settings, lock essential settings
                    errorLabel.Text = "";
                    groupBoxPlayers.Enabled = true;
                    howManyPlayer(playerCount);
                    groupBoxSettings.Enabled = false;
                }
            } 
            else 
            {
                errorLabel.Text = "Enter valid integers in both spaces!";
            }            
        }

        //REGISTER PLAYER NAMES AND COLORS, SEND OFF TO NEXT FORM AND MOVE TO NEXT FORM
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            var player1 = (new player(p1NameTBox.Text, p1ColorLabel.BackColor.ToArgb()));
            var player2 = (new player(p2NameTBox.Text, p2ColorLabel.BackColor.ToArgb()));
            var player3 = (new player(p3NameTBox.Text, p3ColorLabel.BackColor.ToArgb()));
            var player4 = (new player(p4NameTBox.Text, p4ColorLabel.BackColor.ToArgb()));

            //move to next form, pass rgb codes and player names
            this.Hide();
            game f3 = new game(int.Parse(playerCountTBox.Text), int.Parse(endScoreTBox.Text), player1, player2, player3, player4);
            f3.ShowDialog();
            this.Close();
        }

        //FUNCTION TO DYNAMICALLY LOCK UNNECESSARRY INPUT FIELDS
        void howManyPlayer(int playerCount) 
        {
            switch (playerCount) 
            {
                case 2:
                    p3NameTBox.Enabled = false;
                    p3ColorButton.Enabled = false;
                    p4NameTBox.Enabled = false;
                    p4ColorButton.Enabled = false;                   
                    break;

                case 3:
                    p4NameTBox.Enabled = false;
                    p4ColorButton.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        //FUNCTION TO RESET ALL USER CHOICES, ROLLING BACK TO INITISAL STATE OF SETTINGS SCREEN
        private void buttonReset_Click(object sender, EventArgs e)
        {
            p1NameTBox.Text = "";
            p2NameTBox.Text = "";
            p3NameTBox.Text = "";
            p4NameTBox.Text = "";
            errorLabel.Text = "";
            playerCountTBox.Text = "";
            endScoreTBox.Text = "";
            groupBoxPlayers.Enabled = false;
            groupBoxSettings.Enabled = true;
            p1ColorLabel.BackColor = Color.FromArgb(-32640);
            p2ColorLabel.BackColor = Color.FromArgb(-8355585);
            p3ColorLabel.BackColor = Color.FromArgb(-128);
            p4ColorLabel.BackColor = Color.FromArgb(-8323200);
        }

        //RELATIONSHIPS: COLOR LABELS + COLOR DIALOGS + ... BUTTON
        private void p1ColorButton_Click(object sender, EventArgs e)
        {
            p1ColorDialog.ShowDialog();
            p1ColorLabel.BackColor = p1ColorDialog.Color;
        }

        private void p2ColorButton_Click(object sender, EventArgs e)
        {
            p2ColorDialog.ShowDialog();
            p2ColorLabel.BackColor = p2ColorDialog.Color;
        }

        private void p3ColorButton_Click(object sender, EventArgs e)
        {
            p3ColorDialog.ShowDialog();
            p3ColorLabel.BackColor = p3ColorDialog.Color;
        }

        private void p4ColorButton_Click(object sender, EventArgs e)
        {
            p4ColorDialog.ShowDialog();
            p4ColorLabel.BackColor = p4ColorDialog.Color;
        }

        private void buttonExitSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
