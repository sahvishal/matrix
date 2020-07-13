using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Microsoft.CSharp.RuntimeBinder;
using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Audit.Impl
{
    [DefaultImplementation]
    public class ReflectionFactory : IReflectionFactory
    {
        public BsonDocument CreateFromEditModel(dynamic model, bool fromAPI = false)
        {
            if (model.GetType().FullName == "System.Dynamic.ExpandoObject")
            {
                return ((ExpandoObject)model).ToBsonDocument();
            }
            var doc = new BsonDocument();
            PropertyInfo[] members = model.GetType().GetProperties();
            foreach (var propertyInfo in members)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IgnoreAuditAttribute), false).Any())
                {
                    continue;
                }
                var propertyValue = propertyInfo.GetValue(model);

                if (propertyValue == null) continue;

                //if ((propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) || propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)) || propertyInfo.PropertyType.IsArray) || IsCollectionType(propertyValue, propertyInfo))
                if (propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) || propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) || propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) || propertyInfo.PropertyType.IsArray)
                {
                    var items = new BsonArray();
                    items.AddRange(ListProperty(propertyValue, fromAPI));
                    doc.Add(new BsonElement(propertyInfo.Name, items));
                }
                else if (propertyValue.GetType().FullName == "System.Dynamic.ExpandoObject")
                {
                    doc.Add(((ExpandoObject)propertyValue).ToBsonDocument());
                }
                else
                {
                    doc.Add(ProcessPropertyInfo(propertyInfo, propertyValue, fromAPI));
                }
            }
            return doc;
        }

        public IEnumerable<BsonDocument> ListProperty(dynamic collection, bool fromAPI = false)
        {
            var listDoc = new List<BsonDocument>();

            foreach (var item in collection)
            {
                if (IsPrimitiveType(item.GetType()) || IsNumericType(item.GetType()))
                {
                    listDoc.Add(new BsonDocument("Unknown", item));
                }
                else
                {
                    listDoc.Add(ComplexProperty(item, fromAPI));
                }
            }

            return listDoc;
        }

        private BsonDocument ComplexProperty(dynamic property, bool fromAPI = false)
        {
            var propertyDoc = new BsonDocument();
            PropertyInfo[] members = property.GetType().GetProperties();
            foreach (var propertyInfo in members)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IgnoreAuditAttribute), false).Any())
                {
                    continue;
                }
                try
                {
                    ProcessPropertyInfo(property, propertyInfo, propertyDoc, fromAPI);
                }
                catch (NullReferenceException)
                {
                }
            }
            return propertyDoc;
        }

        private void ProcessPropertyInfo(dynamic property, PropertyInfo propertyInfo, BsonDocument propertyDoc, bool fromAPI = false)
        {
            var propertyValue = propertyInfo.GetValue(property);

            if (IsCollectionType(propertyValue, propertyInfo))
            {
                var items = new BsonArray();
                try
                {
                    items.AddRange(ListProperty(propertyValue, fromAPI));
                }
                catch (RuntimeBinderException)
                {
                    if (propertyInfo.PropertyType.IsArray)
                        items.AddRange(ListArray(propertyValue));
                }

                propertyDoc.Add(new BsonElement(propertyInfo.Name, items));
            }
            else
            {
                propertyDoc.Add(ProcessPropertyInfo(propertyInfo, propertyValue, fromAPI));
            }
        }

        private static bool IsCollectionType(dynamic property, PropertyInfo propertyInfo)
        {
            return (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                   || (property is IEnumerable && !(property is string));
        }

        private IEnumerable<BsonDocument> ListArray(Array collection, bool fromAPI = false)
        {
            var listDoc = new List<BsonDocument>();

            foreach (var item in collection)
            {
                listDoc.Add(ComplexProperty(item, fromAPI));
            }

            return listDoc;
        }

        //private void AddExceptions(BsonDocument doc, dynamic model)
        //{
        //    var exceptionElements = _modelExceptionsFactory.ActivityLogExceptions(model);
        //    foreach (var exElement in exceptionElements)
        //    {
        //        doc.Add(exElement);
        //    }
        //}

        private BsonElement ProcessPropertyInfo(PropertyInfo propertyInfo, dynamic propertyValue, bool fromAPI = false)
        {
            var type = propertyInfo.PropertyType;

            if (IsPrimitiveType(type))
            {
                var elementValue = propertyValue ?? string.Empty;
                return (new BsonElement(propertyInfo.Name, elementValue.ToString()));
            }
            if (IsNumericType(type))
            {
                var elementValue = propertyValue.ToString() ?? string.Empty;
                return (new BsonElement(propertyInfo.Name, elementValue));
            }
            if (propertyInfo.PropertyType == typeof(DateTime?) || propertyInfo.PropertyType == typeof(DateTime))
            {
                var elementValue = propertyValue != null
                    ? ((DateTime)propertyValue).Date == DateTime.MinValue ? string.Empty : ((DateTime)propertyValue).ToString()
                    : string.Empty;
                return (new BsonElement(propertyInfo.Name, elementValue));
            }

            if (propertyInfo.ReflectedType != null && propertyInfo.ReflectedType == typeof(MobileResponseModel) && IsCollectionType(propertyValue, propertyInfo))
            {
                var items = new BsonArray();
                try
                {
                    items.AddRange(ListProperty(propertyValue, fromAPI));
                }
                catch (RuntimeBinderException)
                {
                    if (propertyInfo.PropertyType.IsArray)
                        items.AddRange(ListArray(propertyValue));
                }

                return (new BsonElement(propertyInfo.Name, items));
            }
            if (propertyInfo.PropertyType.IsNullableEnum() || propertyInfo.PropertyType.IsEnum)
            {
                var elementValue = propertyValue != null ? propertyValue.ToString() : string.Empty;
                return (new BsonElement(propertyInfo.Name, elementValue));
            }
            else
            {
                var elementValue = propertyValue != null ? ComplexProperty(propertyValue, fromAPI) : string.Empty;
                return (new BsonElement(propertyInfo.Name, elementValue));
            }
        }

        public bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }

        public bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive || type == typeof(string) ||
                   type.FullName.ToLower().Contains("system.nullable");

            //var types = new[] { typeof(string), typeof(int), typeof(long), typeof(bool), typeof(decimal), typeof(double) };

            //var nullTypes = from t in types
            //                where t.IsValueType
            //                select typeof(Nullable<>).MakeGenericType(t);

            //return types.Any(x => x == typeCheck) || nullTypes.Any(x => x == typeCheck);
        }

    }
}
