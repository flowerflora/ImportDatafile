using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class InsuranceData
    {
        public string Policy { get; set; }
        public DateTime Expiry { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
        public double InsuredValue { get; set; }
        public string Construction { get; set; }
        public string BusinessType { get; set; }
        public string Earthquake { get; set; }
        public string Flood { get; set; }
    }
}
