using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bntet0_szop_winform.Forms;

namespace bntet0_szop_winform.Forms
{
    public partial class myMenu : Form
    {
        public myMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            userManagement user = new userManagement();
            user.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            raceManagement race = new raceManagement();
            race.ShowDialog();
        }
    }
}
