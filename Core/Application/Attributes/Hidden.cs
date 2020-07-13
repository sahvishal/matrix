using System;

namespace Falcon.App.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HiddenAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FormatAttribute : Attribute
    {
        public string Format { get; set; }

        public FormatAttribute(string format)
        {
            Format = format;
        }

        public string ToString(Object obj)
        {
            if(obj is DateTime || obj is DateTime?)
            {
                return Convert.ToDateTime(obj).ToString(Format);
            }
            else if(obj is Decimal || obj is double)
            {
                return Convert.ToDecimal(obj).ToString(Format);
            }
            return obj.ToString();
        }
    }

}
