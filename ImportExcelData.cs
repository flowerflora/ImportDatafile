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
    public partial class ImportExcelData : Form
    {
        Data _frmData = new Data();
        string _file = string.Empty;

        public ImportExcelData()
        {
            InitializeComponent();
        }

        public ImportExcelData(Data d)
        {
            _frmData = d;
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
            _frmData.ExcelData = ExcelImport.GetExcelData(_file);
        }
    }
}
