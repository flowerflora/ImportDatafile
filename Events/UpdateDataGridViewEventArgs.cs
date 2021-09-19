using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Events
{
    public class UpdateDataGridViewEventArgs : EventArgs
    {
        private DataSet _ds = null;

        public UpdateDataGridViewEventArgs(DataSet d)
        {
            _ds = d;
        }

        public DataSet GetDataSet
        {
            get
            {
                return _ds;
            }
        }
    }
}
