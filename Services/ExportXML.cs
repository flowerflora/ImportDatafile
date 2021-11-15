using System.Data;

namespace ImportExportData.Services
{
    public static class ExportXML
    {
        public static bool ExportXMLData(DataTable dt, string file)
        {
            dt.WriteXml(file);

            //Export was successful
            return true;
        }
    }
}
