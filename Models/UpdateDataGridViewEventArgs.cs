using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class UpdateDataGridViewEventArgs : EventArgs
    {
        private DataSet _ds = null;

        public UpdateDataGridViewEventArgs(DataSet d)
        {
            _ds = d;
        }

        public DataSet GetExcelDataSet
        {
            get
            {
                return _ds;
            }
        }
    }
}
