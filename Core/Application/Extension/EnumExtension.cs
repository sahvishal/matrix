using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Falcon.App.Core.Application.Extension
{
    public static class EnumExtension
    {
        public static IEnumerable<OrderedPair<long, string>> GetNameValuePairs(this System.Enum enumToUse)
        {
            var typeOfEnum = enumToUse.GetType();
            return (from object value in System.Enum.GetValues(typeOfEnum) select GetPair(value)).ToArray();
        }

        private static OrderedPair<long, string> GetPair(object value)
        {
            return new OrderedPair<long, string>(Convert.ToInt64(value), ((System.Enum)value).GetDescription());
        }

        public static string GetDescription(this System.Enum enumToUse)
        {
            var memberInfo = enumToUse.GetType().GetMember(enumToUse.ToString());
            if (memberInfo.Length < 1) return enumToUse.ToString();

            var descriptionAttribute = (DescriptionAttribute)memberInfo.FirstOrDefault().GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (descriptionAttribute == null) return enumToUse.ToString();
            return descriptionAttribute.Description;
        }

        public static bool IsNullableEnum(this Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }
    }
}
