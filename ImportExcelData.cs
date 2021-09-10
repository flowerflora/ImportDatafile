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
            openDialog.Filter = "Excel (*.xlsx)|*.xls" + "|" +
                                "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = openDialog.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
