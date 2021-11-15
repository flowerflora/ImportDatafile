using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExportData
{
    public partial class Temp : Form
    {
        public Temp()
        {
            InitializeComponent();
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            //IF
            this.btnStop03.BackColor = Color.Crimson;
            this.btnStop03.Text = "P1";
        }

        bool firstClick = false;
        bool secondClick = false;
        bool sfClick = false;
        bool laClick = false;

        private void btnSF_Click(object sender, EventArgs e)
        {
            if (sfClick)
                return;

            if (!firstClick)
                firstClick = true;
            else if (!secondClick)
                secondClick = true;

            if (firstClick && secondClick)
            {
                this.btnStop01.BackColor = Color.LightGreen;
                this.btnStop02.BackColor = Color.LightGreen;
                this.btnStop03.BackColor = Color.LightGreen;
                this.btnStop04.BackColor = Color.LightGreen;
                this.btnStop05.BackColor = Color.LightGreen;
            }

            sfClick = true;
        }

        private void btnLA_Click(object sender, EventArgs e)
        {
            if (laClick)
                return;

            if (!firstClick)
                firstClick = true;
            else if (!secondClick)
                secondClick = true;

            if (firstClick && secondClick)
            {
                this.btnStop01.BackColor = Color.LightGreen;
                this.btnStop02.BackColor = Color.LightGreen;
                this.btnStop03.BackColor = Color.LightGreen;
                this.btnStop04.BackColor = Color.LightGreen;
                this.btnStop05.BackColor = Color.LightGreen;
            }

            laClick = true;
        }
    }
}
