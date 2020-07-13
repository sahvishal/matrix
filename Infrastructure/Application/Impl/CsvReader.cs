using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation(Interface = typeof(ICsvReader))]
    public class CsvReader : ICsvReader
    {
        private readonly long _chunkRowLimit;
        private readonly ICSVSanitizer _csvSanitizer;

        public CsvReader(ISettings settings, ICSVSanitizer csvSanitizer)
        {
            _chunkRowLimit = settings.MaximumDataRowCountLimitForCsvParser;
            _csvSanitizer = csvSanitizer;
            Delimiter = ",";
        }

        //public CsvReader()
        //{
        //    Delimiter = ",";
        //}

        public string Delimiter { get; set; }

        public DataTable Read(string filePath)
        {
            var dtCardiovision = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                {
                    dtCardiovision.Columns.Add(strColumn);
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dtCardiovision.NewRow();
                    int i = 0;
                    foreach (string strValue in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                    {
                        if (i >= dtCardiovision.Columns.Count)
                            break;

                        dr[i] = strValue.Replace("\"", "");
                        i++;
                    }

                    for (int j = i; j < dtCardiovision.Columns.Count; j++)
                        dr[j] = "";

                    dtCardiovision.Rows.Add(dr);
                }
            }

            return dtCardiovision;
        }

        public void Write(string filePath, DataTable source)
        {
            var sw = new StreamWriter(filePath);

            if (source == null) throw new Exception();

            string csvRow = source.Columns.Cast<DataColumn>()
                .Aggregate("", (current, col) => current + (col.ColumnName + Delimiter));
            if (!string.IsNullOrEmpty(csvRow))
            {
                csvRow = csvRow.Substring(0, csvRow.LastIndexOf(Delimiter));
                sw.WriteLine(csvRow + "\n");
            }

            foreach (DataRow row in source.Rows)
            {
                csvRow = source.Columns.Cast<DataColumn>()
                    .Aggregate("",
                        (current, column) =>
                            current +
                            ((row[column.ColumnName] != null && row[column.ColumnName] != DBNull.Value
                                ? row[column.ColumnName].ToString()
                                : "") + Delimiter));

                if (!string.IsNullOrEmpty(csvRow))
                {
                    csvRow = csvRow.Substring(0, csvRow.LastIndexOf(Delimiter));
                }
                sw.WriteLine(csvRow + "\n");
            }
            sw.Close();
        }

        public DataTable ReadWithTextQualifier(string filePath)
        {
            var dataTable = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                foreach (string strColumn in row.Split(new[] { Delimiter }, StringSplitOptions.None))
                {
                    dataTable.Columns.Add(strColumn.Replace("\"", ""));
                }

                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    DataRow dr = dataTable.NewRow();
                    int i = 0;

                    bool cont = false;
                    string cs = "";

                    string[] c = row.Split(new[] { Delimiter }, StringSplitOptions.None);

                    foreach (string y in c)
                    {
                        if (i >= dataTable.Columns.Count)
                            break;

                        string x = y;

                        if (cont)
                        {
                            // End of field
                            if (x.EndsWith("\""))
                            {
                                cs += "," + x.Substring(0, x.Length - 1);
                                dr[i] = cs;
                                i++;
                                cs = "";
                                cont = false;
                                continue;

                            }
                            else
                            {
                                // Field still not ended
                                cs += "," + x;
                                continue;
                            }
                        }

                        // Fully encapsulated with no comma within
                        if (x.StartsWith("\"") && x.EndsWith("\"") && x.Length >= 2)
                        {
                            if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                            {
                                cont = true;
                                cs = x;
                                continue;
                            }

                            dr[i] = x.Substring(1, x.Length - 2);
                            i++;
                            continue;
                        }

                        // Start of encapsulation but comma has split it into at least next field
                        if (x.StartsWith("\"") && (!x.EndsWith("\"") || x.Length == 1))
                        {
                            cont = true;
                            cs += x.Substring(1);
                            continue;
                        }

                        // Non encapsulated complete field
                        dr[i] = x;
                        i++;

                    }

                    for (int j = i; j < dataTable.Columns.Count; j++)
                        dr[j] = "";

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }

        public IEnumerable<DataTable> ReadWithTextQualifierLargeData(string filePath)
        {
            DataTable dataTable = null;
            var firstLineOfFile = true;
            var columnRow = string.Empty;
            var firstRowOfChunk = true;
            var chunkRowCount = 0;

            using (var reader = new StreamReader(filePath))
            {
                while (reader.Peek() != -1)
                {
                    var row = reader.ReadLine();

                    if (firstLineOfFile)
                    {
                        columnRow = row;
                        firstLineOfFile = false;
                        continue;
                    }

                    if (firstRowOfChunk)
                    {
                        dataTable = new DataTable();
                        foreach (string strColumn in columnRow.Split(new[] { Delimiter }, StringSplitOptions.None))
                        {
                            dataTable.Columns.Add(strColumn.Replace("\"", ""));
                        }
                        firstRowOfChunk = false;
                    }

                    DataRow dr = dataTable.NewRow();
                    int i = 0;

                    bool cont = false;
                    string cs = "";

                    string[] c = row.Split(new[] { Delimiter }, StringSplitOptions.None);

                    foreach (string y in c)
                    {
                        if (i >= dataTable.Columns.Count)
                            break;

                        string x = y;

                        if (cont)
                        {
                            // End of field
                            if (x.EndsWith("\""))
                            {
                                cs += "," + x.Substring(0, x.Length - 1);
                                dr[i] = cs;
                                i++;
                                cs = "";
                                cont = false;
                                continue;

                            }
                            else
                            {
                                // Field still not ended
                                cs += "," + x;
                                continue;
                            }
                        }

                        // Fully encapsulated with no comma within
                        if (x.StartsWith("\"") && x.EndsWith("\"") && x.Length >= 2)
                        {
                            if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                            {
                                cont = true;
                                cs = x;
                                continue;
                            }

                            dr[i] = x.Substring(1, x.Length - 2);
                            i++;
                            continue;
                        }

                        // Start of encapsulation but comma has split it into at least next field
                        if (x.StartsWith("\"") && (!x.EndsWith("\"") || x.Length == 1))
                        {
                            cont = true;
                            cs += x.Substring(1);
                            continue;
                        }

                        // Non encapsulated complete field
                        dr[i] = x;
                        i++;

                    }

                    for (int j = i; j < dataTable.Columns.Count; j++)
                        dr[j] = "";

                    dataTable.Rows.Add(dr);
                    chunkRowCount++;
                    if (chunkRowCount == _chunkRowLimit)
                    {
                        firstRowOfChunk = true;
                        chunkRowCount = 0;
                        yield return dataTable;
                        dataTable = null;
                    }
                }
            }

            if (dataTable != null)
                yield return dataTable;
        }

        public DataTable ConvertCsvToDataTable(string path, bool hasHeader, string seperator)
        {
            var dt = new DataTable();

            using (var myReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(path))
            {
                myReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                myReader.Delimiters = new[] { Delimiter };

                //'Loop through all of the fields in the file.  
                //'If any lines are corrupt, report an error and continue parsing.  
                bool firstRow = true;
                while (!myReader.EndOfData)
                {
                    try
                    {
                        string[] currentRow = myReader.ReadFields();

                        //Add the header columns
                        if (hasHeader && firstRow)
                        {
                            var index = 0;
                            foreach (string c in currentRow)
                            {
                                dt.Columns.Add(c + seperator + index, typeof(string));
                                index++;
                            }

                            firstRow = false;
                            continue;
                        }

                        //Create a new row
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);

                        //Loop thru the current line and fill the data out
                        for (int c = 0; c < currentRow.Count(); c++)
                        {
                            dr[c] = string.IsNullOrEmpty(currentRow[c]) ? null : currentRow[c];
                        }
                    }
                    catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dt;
        }

        public DataTable CsvToDataTable(string path, bool hasHeader, string seperator = ",")
        {
            var dt = new DataTable();

            using (var myReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(path))
            {
                myReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                myReader.Delimiters = new[] { Delimiter };

                //'Loop through all of the fields in the file.  
                //'If any lines are corrupt, report an error and continue parsing.  
                bool firstRow = true;
                while (!myReader.EndOfData)
                {
                    try
                    {
                        string[] currentRow = myReader.ReadFields();

                        //Add the header columns
                        if (hasHeader && firstRow)
                        {
                            //var index = 0;
                            foreach (string c in currentRow)
                            {
                                dt.Columns.Add(c /*+ seperator + index*/, typeof(string));
                                //index++;
                            }

                            firstRow = false;
                            continue;
                        }

                        //Create a new row
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);

                        //Loop thru the current line and fill the data out
                        for (int c = 0; c < currentRow.Count(); c++)
                        {
                            dr[c] = string.IsNullOrEmpty(currentRow[c]) ? null : currentRow[c];
                        }
                    }
                    catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dt;
        }

        public void ConvertDataTableToCsv(DataTable dt, string filePath, string seperator)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            var sw = new StreamWriter(filePath);
            try
            {
                string[] stringSeparators = { seperator };

                IEnumerable<string> columnNames =
                    dt.Columns.Cast<DataColumn>()
                        .Select(column => _csvSanitizer.EscapeString(column.ColumnName.Split(stringSeparators, StringSplitOptions.None)[0]));

                var header = string.Join(",", columnNames);

                sw.WriteLine(header);

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields =
                        row.ItemArray.Select(field => _csvSanitizer.EscapeString(field.ToString()));
                    sw.WriteLine(string.Join(",", fields));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }

        }

        public void RemoveEmptyColumnsFromCsv(string filePath)
        {
            var dt = ConvertCsvToDataTable(filePath, true, "_$$");

            foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
            {
                if (dt.AsEnumerable().All(dr => dr.IsNull(column)) || dt.AsEnumerable().All(dr => dr.IsNull(column)))
                    dt.Columns.Remove(column);
            }

            ConvertDataTableToCsv(dt, filePath, "_$$");
        }

        public char GetFileDelimiter(string filePath)
        {
            IList<char> separators = new[] { ',', '\t' };
            IList<int> separatorsCount = new int[separators.Count];

            var row = 0;
            const int rowCount = 2;

            bool quoted = false;
            bool firstChar = true;
            using (var reader = new StreamReader(filePath))
            {
                while (row < rowCount)
                {
                    int character = reader.Read();

                    switch (character)
                    {
                        case '"':
                            if (quoted)
                            {
                                if (reader.Peek() != '"') // Value is quoted and 
                                    // current character is " and next character is not ".
                                    quoted = false;
                                else
                                    reader.Read(); // Value is quoted and current and 
                                // next characters are "" - read (skip) peeked qoute.
                            }
                            else
                            {
                                if (firstChar) // Set value as quoted only if this quote is the 
                                    // first char in the value.
                                    quoted = true;
                            }
                            break;
                        case '\n':
                            if (!quoted)
                            {
                                ++row;
                                firstChar = true;
                                continue;
                            }
                            break;
                        case -1:
                            row = rowCount;
                            break;
                        default:
                            if (!quoted)
                            {
                                int index = separators.IndexOf((char)character);
                                if (index != -1)
                                {
                                    ++separatorsCount[index];
                                    firstChar = true;
                                    continue;
                                }
                            }
                            break;
                    }

                    if (firstChar)
                        firstChar = false;
                }

                int maxCount = separatorsCount.Max();

                return maxCount == 0 ? '\0' : separators[separatorsCount.IndexOf(maxCount)];
            }
        }
    }
}
