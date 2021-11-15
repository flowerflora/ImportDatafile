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
        bool _success = false;

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

            //Raddio Button
            this.rbExcel.Checked = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            string ext = string.Empty;

            if (!this.PerformValidation())
                return;

            file = this.txtLocation.Text + "\\" +
                   this.txtFileName.Text.Trim();

            if (this.rbExcel.Checked)
            {
                file += ".xlsx";
                _success = ExportExcel.ExportExcelData(_dt, file);
            }
            else if (this.rbXML.Checked)
            {
                file += ".xml";
                _success = ExportXML.ExportXMLData(_dt, file);
            }

            string result = string.Empty;

             if (_success)
            {
                result = " was successful!";
            }
            else
            {
                result = " failed!";
            }

            MessageBox.Show("Export " + file + result,
                            Titles.MessageBoxTitle,
                            MessageBoxButtons.OK);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.txtLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private bool PerformValidation()
        {
            if (String.IsNullOrEmpty(this.txtLocation.Text.Trim()))
            {
                MessageBox.Show("Directory must be provided!",
                                Titles.MessageBoxTitle,
                                MessageBoxButtons.OK);
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtFileName.Text.Trim()))
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
