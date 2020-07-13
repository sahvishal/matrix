using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Falcon.App.UI.HtmlHelpers
{

    public static class ModelMetadataHelper
    {
        public static string DescriptionForModel(this HtmlHelper helper)
        {
            Type containerType = helper.ViewData.ModelMetadata.ContainerType;
            string propertyName = helper.ViewData.ModelMetadata.PropertyName;
            DescriptionAttribute descriptionAttribute = containerType.GetProperty(propertyName).GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>().SingleOrDefault();

            if (descriptionAttribute == null)
                return "";
            return descriptionAttribute.Description ?? "";
        }
    }
}
