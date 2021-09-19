using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    public partial class ExportData : Form
    {
        DataTable _dt = new DataTable();

        public ExportData()
        {
            InitializeComponent();
        }

        public DataTable Data 
        {
            set
            {
                _dt = value;
            }

        }

        private void ExportData_Load(object sender, EventArgs e)
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

            //TextBox
            this.txtLocation.Enabled = false;            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            string ext = string.Empty;

            if (!this.PerformValidation())
                return;

            if (this.rbExcel.Checked)
                ext = ".xlsx";
            else if (this.rbXML.Checked)
                ext = ".xml";

            file = this.txtLocation.Text + "\\" +
                    this.txtFileName.Text.Trim() + ext;

             if (ExportExcel.ExportExcelData(_dt, file))
            {
                MessageBox.Show("Export " + file + " was successful!",
                                Titles.MessageBoxTitle,
                                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Export " + file + " failed!",
                                Titles.MessageBoxTitle,
                                MessageBoxButtons.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private bool PerformValidation()
        {
            if (String.IsNullOrEmpty(this.txtLocation.Text))
            {
                MessageBox.Show("Directory must be provided!",
                                Titles.MessageBoxTitle,
                                MessageBoxButtons.OK);
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtFileName.Text))
            {
                MessageBox.Show("A File Name must be provided!",
                                Titles.MessageBoxTitle,
                                MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
