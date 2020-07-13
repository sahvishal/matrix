using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Falcon.App.Core.Application;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class ExcelReader : IExcelReader
    {
        public DataSet ReadfromExcelintoDataset(string filePath, bool hasHeaders = true)
        {
            string header = hasHeaders ? "Yes" : "No";
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + header + ";IMEX=1\"";

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=" + header + ";IMEX=1\"";


            var output = new DataSet();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (schemaTable == null) return null;

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    var cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn) { CommandType = CommandType.Text };

                    var outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
            }
            return output;
        }

        public void WriteToExcel(string filePath, DataSet source)
        {
            var excelDoc = new StreamWriter(filePath);
            string startExcelXml = GetStartExcelXmlTag();

            const string endExcelXml = "</Workbook>";

            excelDoc.Write(startExcelXml);
            int sheetCount = 1;

            foreach (DataTable dt in source.Tables)
            {
                WriteaTableintoExcelSheet(excelDoc, dt, ref sheetCount);
                sheetCount++;
            }

            excelDoc.Write(endExcelXml);
            excelDoc.Close();
        }

        private static void WriteaTableintoExcelSheet(StreamWriter excelDoc, DataTable dt, ref int sheetCount)
        {
            excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
            excelDoc.Write("<Table>");

            excelDoc.Write("<Row>");
            for (int x = 0; x < dt.Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(dt.Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");

            int rowCount = 0;
            foreach (DataRow x in dt.Rows)
            {
                rowCount++;

                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "

                for (int y = 0; y < dt.Columns.Count; y++)
                {
                    Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string xmLstring = x[y].ToString();
                            xmLstring = xmLstring.Trim();
                            xmLstring = xmLstring.Replace("&", "&");
                            xmLstring = xmLstring.Replace(">", ">");
                            xmLstring = xmLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(xmLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  

                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000

                            //The Following Code puts the date stored in XMLDate 

                            //to the format above

                            var xmlDate = (DateTime)x[y];
                            string xmlDatetoString; //Excel Converted Date

                            xmlDatetoString = xmlDate.Year +
                                 "-" +
                                 (xmlDate.Month < 10 ? "0" +
                                 xmlDate.Month : xmlDate.Month.ToString()) +
                                 "-" +
                                 (xmlDate.Day < 10 ? "0" +
                                 xmlDate.Day : xmlDate.Day.ToString()) +
                                 "T" +
                                 (xmlDate.Hour < 10 ? "0" +
                                 xmlDate.Hour : xmlDate.Hour.ToString()) +
                                 ":" +
                                 (xmlDate.Minute < 10 ? "0" +
                                 xmlDate.Minute : xmlDate.Minute.ToString()) +
                                 ":" +
                                 (xmlDate.Second < 10 ? "0" +
                                 xmlDate.Second : xmlDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(xmlDatetoString);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;
                        default:
                            throw (new Exception(rowType + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }
            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
        }

        private static string GetStartExcelXmlTag()
        {
            /*
           <xml version>
           <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
           xmlns:o="urn:schemas-microsoft-com:office:office"
           xmlns:x="urn:schemas-microsoft-com:office:excel"
           xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
           <Styles>
           <Style ss:ID="Default" ss:Name="Normal">
             <Alignment ss:Vertical="Bottom"/>
             <Borders/>
             <Font/>
             <Interior/>
             <NumberFormat/>
             <Protection/>
           </Style>
           <Style ss:ID="BoldColumn">
             <Font x:Family="Swiss" ss:Bold="1"/>
           </Style>
           <Style ss:ID="StringLiteral">
             <NumberFormat ss:Format="@"/>
           </Style>
           <Style ss:ID="Decimal">
             <NumberFormat ss:Format="0.0000"/>
           </Style>
           <Style ss:ID="Integer">
             <NumberFormat ss:Format="0"/>
           </Style>
           <Style ss:ID="DateLiteral">
             <NumberFormat ss:Format="mm/dd/yyyy;@"/>
           </Style>
           </Styles>
           <Worksheet ss:Name="Sheet1">
           </Worksheet>
           </Workbook>
           */

            return "<xml version>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n <Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                  "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                  "</Styles>\r\n ";

        }
    }
}