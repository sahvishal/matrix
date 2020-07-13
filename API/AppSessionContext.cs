using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;

namespace API
{
    [DefaultImplementation]
    public class AppSessionContext : IAppSessionContext
    {
        public const string DictionaryKey = "_ReqLevelDictionary_";

        private IDictionary<string, object> Dictionary
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(DictionaryKey))
                {
                    HttpContext.Current.Items.Add(DictionaryKey, new Dictionary<string, object>());
                }
                return HttpContext.Current.Items[DictionaryKey] as IDictionary<string, object>;
            }
            set { HttpContext.Current.Items[DictionaryKey] = value; }
        }

        public void AddItem(string key, object item)
        {
            if (Dictionary.ContainsKey(key))
                throw new InvalidDataException("Already an object exists.");

            if (item == null) throw new InvalidOperationException("Cannot add null to the Storage.");

            Dictionary.Add(key, item);
        }

        public void UpdateItem(string key, object item)
        {
            if (!Dictionary.ContainsKey(key))
                AddItem(key, item);
            else
            {
                Dictionary[key] = item;
            }
        }

        public object Get(string key)
        {
            if (Dictionary.ContainsKey(key))
                return Dictionary[key];

            return null;
        }

        public void Remove(string key)
        {
            if (Dictionary.ContainsKey(key))
                Dictionary.Remove(key);
        }

        public void ClearStorage()
        {
            foreach (var o in Dictionary)
            {
                if (o.Value is IDisposable)
                {
                    (o.Value as IDisposable).Dispose();
                }
            }

            Dictionary.Clear();

            HttpContext.Current.Items.Remove(DictionaryKey);
        }
    }
}