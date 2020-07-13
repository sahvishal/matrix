using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Application.Impl
{
    public class CSVColumn<T>
    {
        public string Name { get; set; }
        public Func<T, string> Func { get; set; }

        public CSVColumn(string name, Func<T, string> func)
        {
            Name = name;
            Func = func;
        }
    }

    public class CSVExporter<T>
    {
        public List<CSVColumn<T>> Columns { get; set; }
        public ICSVSanitizer  Sanitizer { get; set; }

        public CSVExporter(params CSVColumn<T>[] columns)
            : this(new CSVSanitizer(), columns)
        {}

        public CSVExporter(ICSVSanitizer sanitizer, params CSVColumn<T>[] columns)
        {
            Sanitizer = sanitizer;
            Columns = columns.ToList();
        }

        public string Header
        {
            get
            {
                return string.Join(",", Columns.Select(c => Sanitizer.EscapeString(c.Name)).ToArray());
            }
        }

        public string ExportObject(T obj)
        {            
            IEnumerable<string> enumerable = Columns.Select(c => ColumnValue(c, obj));
            return string.Join(",", enumerable.ToArray());
        }

        private string ColumnValue(CSVColumn<T> column, T obj)
        {
            try
            {
                if (column.Name == "Zip")
                    return "=" + Sanitizer.EscapeString(column.Func(obj));
                return Sanitizer.EscapeString(column.Func(obj));
            }
            catch
            {
                return "";
            }
        }

        public IEnumerable<string> ExportObjects(IEnumerable<T> obj)
        {
            foreach (string csv in obj.Select(o => ExportObject(o)))
            {
                yield return csv;
            }
        }

        public CSVExporter<T> AddColumn(string name, Func<T, string> func)
        {
            Columns.Add(new CSVColumn<T>(name, func));
            return this;
        }
    }
}