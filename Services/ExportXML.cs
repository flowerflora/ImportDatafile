using System.Data;

namespace WindowsFormsApp1.Services
{
    public class ExportXML
    {
        public static bool ExportXMLData(DataTable dt, string file)
        {
            dt.WriteXml(file);

            //Export was successful
            return true;
        }
    }
}
