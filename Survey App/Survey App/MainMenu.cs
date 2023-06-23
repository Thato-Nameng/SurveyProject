using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey_App
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnFOS_Click(object sender, EventArgs e)
        {
            UserSurvey userSurvey = new UserSurvey();
            this.Hide();
            userSurvey.Show();
        }

        private void btnVSR_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            this.Hide();
            results.Show();
        }
    }
}
