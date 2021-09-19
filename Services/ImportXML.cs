using System;
using System.Data;

namespace WindowsFormsApp1.Services
{
    public class ImportXML
    {
        static DataSet _ds = new DataSet();
        static string _value = string.Empty;

        public static DataSet GetXMLData(string file)
        {
            _ds.ReadXml(file);

            FixDateTimeCol();
            FixCurrencyCol();

            return _ds;
        }

        private static void FixDateTimeCol()
        {
            foreach (DataTable dt in _ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    _value = row[1].ToString();

                    if (_value.Contains("T"))
                    {
                        _value = _value.Substring(0, _value.IndexOf("T"));
                        _value = _value.Replace("-", "/");
                        DateTime date = DateTime.Parse(_value);
                        _value = string.Format("{0:MM/d/yyyy}", date);
                        row[1] = _value;
                    }
                }

                dt.AcceptChanges();
            }           
        }

        private static void FixCurrencyCol()
        {
            foreach (DataTable dt in _ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    _value = row[5].ToString();

                    int amt = int.Parse(_value);

                    row[5] = string.Format("{0:#,###,###,##0}", amt);
                }

                dt.AcceptChanges();
            }

        }

    }
}
