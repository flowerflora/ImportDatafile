﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Events;

namespace WindowsFormsApp1
{
    public partial class ImportExcelData : Form
    {
        //****************************************************
        //A Delegate is similar to a POINTER. They are used to 
        //implement events. For this example, the delegate
        //"UpdateDGVHandler" is wired to the Data.cs form.
        //****************************************************

        //Delegate is created to update the DataGridView in the Data Form
        //The "UpdateDataGridViewEventArgs" is a CLASS we create in the Events Folder
        public delegate void UpdateDGVHandler(object sender, 
                                              UpdateDataGridViewEventArgs e);

        //Event
        public event UpdateDGVHandler UpdateDataGridView;

        //Variables
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

            //Set Tile of OpenFileDialog
            openDialog.Title = "Select An Excel File";

            //Set the File Filter of OpenFileDialog
            openDialog.Filter = "Excel 7.0 (*.xlsx)|*.xlsx" + "|" +
                                "Excel (*.xls)|*.xls" + "|" +
                                "CSV (*.csv)|*.csv" + "|" +
                                "All Files (*.*)|*.*";

            //Get the OK press of the Dialog Box
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //Get Selected File
                _file = openDialog.FileName;
                this.txtFile.Text = _file;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Change cursor
            Cursor.Current = Cursors.WaitCursor;

            DataSet ds = ExcelImport.GetExcelData(_file);

            //Event Class which is used with the Delegates
            UpdateDataGridViewEventArgs args = new UpdateDataGridViewEventArgs(ds);
            //Event
            UpdateDataGridView(this, args);
            
            //Return cursor
            Cursor.Current = Cursors.WaitCursor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //User wants to close the form
            this.Dispose();
        }
    }
}
