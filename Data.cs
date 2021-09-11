using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Data : Form
    {
        private DataSet _dsData = null;

        public Data()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Labels
            this.lblSearch.Text = "Search Criteria";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Create Instance of the Import Excel Form
            ImportExcelData frmImport = new ImportExcelData();

            //Access the Event which is used by the Delegate
            frmImport.UpdateDataGridView += new ImportExcelData.UpdateDataGridViewHandler(PopulateDataGridView);
            //Show the form
            frmImport.ShowDialog();
        }

        private void PopulateDataGridView(object sender, UpdateDataGridViewEventArgs e)
        {
            //Create DataTable
            DataTable dt = e.GetExcelDataSet.Tables[0];

            //Get Column Names from DataTable
            int index = 0;
            foreach(DataColumn dc in dt.Columns)
            {
                dc.ColumnName = dt.Rows[0][index].ToString();
                index++;
            }

            //**********************************************
            //Delete first row which contains column headers
            //**********************************************
            //Create a DataRow
            DataRow[] dr = dt.Select();
            //Delete The first Row
            dr[0].Delete();
            //Have the DataTable Accept the Changes
            dt.AcceptChanges();

            //Set the DataSource of the DataGridView to the DataTable
            this.grdData.DataSource = dt;
        }
    }
}
