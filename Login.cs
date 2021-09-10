using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private DataSet _dsData = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
        }

        public DataSet ExcelData 
        {
            set { _dsData = value; } 
        }

        private void SetControls()
        {
            //Labels
            this.lblSearch.Text = "Search Criteria";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportExcelData frmImport = new ImportExcelData();
            frmImport.ShowDialog();
        }
    }
}
