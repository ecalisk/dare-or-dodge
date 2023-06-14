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
    public partial class game : Form
    {

        int PlayerCount;
        int EndScore;
        int turn = 0;
        List<int> Wallets = new List<int>() { 0, 0, 0, 0 };
        List<int> Banks = new List<int>() { 0, 0, 0, 0 };

        public game(int playerCount, int endScore, player player1, player player2, player player3, player player4)
        {
            InitializeComponent();

            //APPLY PANEL BACKGROUND COLORS FROM PLAYERS' INPUT
            p1GroupBox.BackColor = Color.FromArgb(player1.color);
            p2GroupBox.BackColor = Color.FromArgb(player2.color);
            p3GroupBox.BackColor = Color.FromArgb(player3.color);
            p4GroupBox.BackColor = Color.FromArgb(player4.color);

            //PLACE PANEL NAMES FROM PLAYERS' INPUT
            p1GroupBox.Text = player1.name;
            p2GroupBox.Text = player2.name;
            p3GroupBox.Text = player3.name;
            p4GroupBox.Text = player4.name;

            drawGameMap(playerCount);
            updateColors();

            PlayerCount = playerCount;
            EndScore = endScore;

            p1GroupBox.Text = checkName(p1GroupBox.Text, 1);
            p2GroupBox.Text = checkName(p2GroupBox.Text, 2);
            p3GroupBox.Text = checkName(p3GroupBox.Text, 3);
            p4GroupBox.Text = checkName(p4GroupBox.Text, 4);
        }

        //DECIDE WHICH PANELS ARE NOT TO BE DISPLAYED
        void drawGameMap(int playerCount)
        {
            switch (playerCount)
            {
                case 2:
                    p3GroupBox.Visible = false;
                    p4GroupBox.Visible = false;
                    break;

                case 3:
                    p4GroupBox.Visible = false;
                    break;

                default:
                    break;
            }
        }

        //REFLECT CHANGES IN NUMBERS IN APPROPRIATE LABELS
        void updateNumbers()
        {
            p1Bank.Text = (Banks[0]).ToString();
            p2Bank.Text = (Banks[1]).ToString();
            p3Bank.Text = (Banks[2]).ToString();
            p4Bank.Text = (Banks[3]).ToString();
            p1Wallet.Text = (Wallets[0]).ToString();
            p2Wallet.Text = (Wallets[1]).ToString();
            p3Wallet.Text = (Wallets[2]).ToString();
            p4Wallet.Text = (Wallets[3]).ToString();
        }

        //ROLL A DICE AND RETURN THE RESULT 1-6
        int rollDice() 
        {
            Random rand = new Random();
            return rand.Next(1, 6);
        }

        //WHEN 1 ROUND IS OVER GIVE THE TURN BACK TO PLAYER 1
        void calculateTurns() 
        {
            turn++;
            if (turn == PlayerCount) 
            {
                turn = 0;
            }
            updateColors();
        }

        //CHECK IF ANY NAMES ARE EMPTY, RETURN ALTERNATIVE NAMING
        string checkName(string Name, int player) 
        {
            if(Name == "") 
            {
                return $"Player {player}";
            }
            else 
            {
                return Name;
            }
        }

        //END THE GAME WHEN END SCORE HAS BEEN REACHED, SIGNAL IF IT IS TIME TO END
        bool checkGameEnd() 
        {
            if (Banks[turn] >= EndScore) 
            {
                switch (turn)
                {
                    case 0:
                        winLabel.Text = $"{p1GroupBox.Text} has won with {p1Bank.Text} golds!";
                        break;

                    case 1:
                        winLabel.Text = $"{p2GroupBox.Text} has won with {p2Bank.Text} golds!";
                        break;

                    case 2:
                        winLabel.Text = $"{p3GroupBox.Text} has won with {p3Bank.Text} golds!";
                        break;

                    case 3:
                        winLabel.Text = $"{p4GroupBox.Text} has won with {p4Bank.Text} golds!";
                        break;

                    default:
                        break;
                }

                buttonDare.Enabled = false;
                buttonDodge.Enabled = false;
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        //DARE BUTTON CLICK
        private void buttonDare_Click(object sender, EventArgs e)
        {
            int temp = rollDice();
            diceLabel.Text = (temp).ToString();

            //dice shows 1, wallet must become zero and turn must pass
            if (temp == 1)
            {
                Wallets[turn] = 0;
                updateNumbers();
                calculateTurns();
            }
            // dice shows 2-6, add temp to wallet balance, enable dodge button
            else 
            {
                Wallets[turn] += temp;
                updateNumbers();
                buttonDodge.Enabled = true;
            }
        }

        //DODGE BUTTON CLICK
        private void buttonDodge_Click(object sender, EventArgs e)
        {
            //save wallet grand total to bank
            Banks[turn] += Wallets[turn];
            Wallets[turn] = 0;
            updateNumbers();
            
            //see if end game has arrived, if so don't change turn and colors
            if(checkGameEnd()) 
            {
                //finish
            }
            else 
            {
                calculateTurns();
                buttonDodge.Enabled = false;
            }
        }

        //UPDATE COLORS CORRESPONDANTLY TO TURN
        void updateColors() 
        {
            switch (turn)
            {
                case 0:
                    buttonDare.BackColor = p1GroupBox.BackColor;
                    buttonDodge.BackColor = p1GroupBox.BackColor;
                    diceLabel.ForeColor = p1GroupBox.BackColor;
                    break;

                case 1:
                    buttonDare.BackColor = p2GroupBox.BackColor;
                    buttonDodge.BackColor = p2GroupBox.BackColor;
                    diceLabel.ForeColor = p2GroupBox.BackColor;
                    break;

                case 2:
                    buttonDare.BackColor = p3GroupBox.BackColor;
                    buttonDodge.BackColor = p3GroupBox.BackColor;
                    diceLabel.ForeColor = p3GroupBox.BackColor; ;
                    break;

                case 3:
                    buttonDare.BackColor = p4GroupBox.BackColor;
                    buttonDodge.BackColor = p4GroupBox.BackColor;
                    diceLabel.ForeColor = p4GroupBox.BackColor;
                    break;

                default:
                    break;
            }
        }

        //BACK BUTTON, RETURN BACK TO SETTINGS
        private void buttonBackGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings f2 = new settings();
            f2.ShowDialog();
            this.Close();
        }

        //EXIT APP
        private void buttonExitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
