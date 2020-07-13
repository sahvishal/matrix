using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Application.Impl
{
    public class ExportableDataGeneratorProcessManager<T, TN>
        where T : ViewModelBase
        where TN : ModelFilterBase
    {
        private static IDictionary<string, ExportableDataGenerator<T, TN>> ProcessCollection { get; set; }

        public ExportableDataGeneratorProcessManager()
        {
            if(ProcessCollection == null)
                ProcessCollection = new Dictionary<string, ExportableDataGenerator<T, TN>>();
        }

        public void Add(string id, ExportableDataGenerator<T, TN> process)
        {
            if (!ProcessCollection.ContainsKey(id))
            {
                ProcessCollection.Add(id, process);
            }
        }

        public void Remove(string id)
        {
            if (ProcessCollection.ContainsKey(id))
                ProcessCollection.Remove(id);
        }

        public int GetStatus(string id)
        {
            if (!ProcessCollection.ContainsKey(id)) return 100;

            var process = ProcessCollection[id];
            return Convert.ToInt32(process.Status);
        }

        public static CSVExporter<TV> GetCsvExporter<TV>()
            where TV : ViewModelBase
        {
            var members = (typeof(TV)).GetMembers();
            var exporter = new CSVExporter<TV>();

            var check = new Func<string, FormatAttribute, Func<TV, string>>((propName, formatter) => ((c) =>
                                                                                                          {

                                                                                                              var obj = c.GetType().GetProperty(propName).GetValue(c, null);
                                                                                                              if (obj == null)
                                                                                                                  return string.Empty;
                                                                                                              if (formatter != null)
                                                                                                              {
                                                                                                                  return formatter.ToString(obj);
                                                                                                              }
                                                                                                              return obj.ToString();
                                                                                                          }));

            foreach (var memberInfo in members)
            {
                if (memberInfo.MemberType != MemberTypes.Property)
                    continue;

                var propInfo = (memberInfo as PropertyInfo);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                        continue;
                }
                else
                    continue;

                string propertyName = memberInfo.Name;
                bool isHidden = false;
                FormatAttribute formatter = null;

                var attributes = propInfo.GetCustomAttributes(false);
                if (!attributes.IsNullOrEmpty())
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute is HiddenAttribute)
                        {
                            isHidden = true;
                            break;
                        }
                        if (attribute is FormatAttribute)
                        {
                            formatter = (FormatAttribute)attribute;
                        }
                        if (attribute is DisplayNameAttribute)
                        {
                            propertyName = (attribute as DisplayNameAttribute).DisplayName;
                        }
                    }
                }

                if (isHidden) continue;

                exporter.AddColumn(propertyName, check(memberInfo.Name, formatter));
            }

            return exporter;
        }


    }
}