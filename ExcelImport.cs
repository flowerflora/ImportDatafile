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
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = (DataSet)excelReader;
            //...
            //4. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = true;
            
            ds = excelReader.AsDataSet();

            //dt.Load(excelReader);
            //5. Data Reader methods

            //while (excelReader.Read())
            //{
                //excelReader.GetInt32(0);
            //}

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            return ds;
        }

        public static DataSet GetExcelData3(string file)
        {

            string sSheetName = "Sheet2"; // "PolicyData";
            string sql = "select* from[" +sSheetName + "]";
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + 
                             ";Extended Properties='Excel 12.0 Xml';HDR=YES;Persist Security Info=False";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;IMEX=1;'";
            //string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};" +
            //                 "Extended Properties='Excel 12.0 Xml;HDR=YES""", newFileName);

            System.Data.OleDb.OleDbConnection oleConnection;
            System.Data.DataSet dsData;
            System.Data.OleDb.OleDbDataAdapter command;

            oleConnection = new System.Data.OleDb.OleDbConnection(connStr);
            command = new System.Data.OleDb.OleDbDataAdapter(sql, oleConnection);
            //command.TableMappings.Add("Table", "Net-informations.com");
            dsData = new System.Data.DataSet();
            command.Fill(dsData);

            return dsData;
        }
    }
}
