using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class ExcelImport
    {
        public static DataSet GetExcelData(string file)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);

            //Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Get DataSet - The spreadsheet will be created in the ds.Tables
            ds = excelReader.AsDataSet();

            //Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            return ds;
        }
    }
}
