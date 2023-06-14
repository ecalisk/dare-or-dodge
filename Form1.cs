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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dare_or_dodge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //MOVE TO THE NEXT FORM
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings f2 = new settings();
            f2.ShowDialog();
            this.Close();
        }

        //EXIT THE APP
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
