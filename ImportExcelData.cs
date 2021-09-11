using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class ImportExcelData : Form
    {

        //Delegate will update the DataGridView in the Data Form
        public delegate void UpdateDataGridView(object sender, UpdateDataGridViewEventArgs e);

        string _file = string.Empty;

        public ImportExcelData()
        {
            InitializeComponent();
        }

        private void ImportExcelData_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Label
            this.lblFile.Text = "Selected File";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select An Excel File";
            openDialog.Filter = "Excel 7.0 (*.xlsx)|*.xlsx" + "|" +
                                "Excel (*.xls)|*.xls" + "|" +
                                "CSV (*.csv)|*.csv" + "|" +
                                "All Files (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _file = openDialog.FileName;
                this.txtFile.Text = _file;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
           DataSet ds = ExcelImport.GetExcelData(_file);
        }
    }
}
