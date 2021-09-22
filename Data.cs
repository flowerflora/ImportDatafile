using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Events;

namespace WindowsFormsApp1
{
    public partial class Data : Form
    {
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Labels
            this.lblSearch.Text = "Search Criteria";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Create Instance of the Import Excel Form
            ImportExcelData frmImport = new ImportExcelData();

            //Access the Event which is used by the Delegate
            //Pass in a method on THIS FORM to the ImportExcelData Form
            //This will cause the Deletegate on the ImportExcewlData Form
            //To access the method on this Form
            frmImport.UpdateDataGridView += 
                new ImportExcelData.UpdateDGVHandler(PopulateDataGridView);
            //Show the form
            frmImport.ShowDialog();
        }

        private void PopulateDataGridView(object sender, UpdateDataGridViewEventArgs e)
        {
            //**********************************************************************
            //This method is accessed from the ImportExcelData form via the delegate
            //**********************************************************************

            //Create DataTable
            DataTable dt = e.GetDataSet.Tables[0];

            //Set the DataSource of the DataGridView to the DataTable
            this.grdData.DataSource = ProcessDataSet(dt);

            //Format columns in the DataGridView
            FormatDataGridViewColumns();
            FormatDataGridViewColumnHeaders();
        }

        private void FormatDataGridViewColumnHeaders()
        {
            //Set the Background Color of the Column Header
            this.grdData.EnableHeadersVisualStyles = false;
            this.grdData.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            this.grdData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Set the Font for the Column Header
            this.grdData.ColumnHeadersDefaultCellStyle.Font =
                new Font(new FontFamily("Arial"), 12, FontStyle.Bold);

            //Autosize the coulumns
            this.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FormatDataGridViewColumns()
        {
            //Format Column as a Short Date Time. Example -> 9/11/21
            this.grdData.Columns["Expiry"].DefaultCellStyle.Format =
                String.Format("d");
            //Align Right
            this.grdData.Columns["Expiry"].DefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleRight;

            //Format Column as Currency
            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Format =
                String.Format("C");
            //Align Right
            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        private DataTable ProcessDataSet(DataTable dt)
        {
            //Variable
            int index = 0;

            //Get Column Names from the DataTable
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnName = dt.Rows[0][index].ToString();
                index++;
            }

            //**********************************************
            //Delete first row which contains column headers
            //**********************************************
            //Create a DataRow and populate with the DataTable
            DataRow[] dr = dt.Select();
            //Delete The first Row
            dr[0].Delete();
            //Update the DataTable by Accept the Changes
            dt.AcceptChanges();

            return dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
