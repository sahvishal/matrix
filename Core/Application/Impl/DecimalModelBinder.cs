using System;
using System.Web.Mvc;

namespace Falcon.App.Core.Application.Impl
{
    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            decimal value;
            return valueProviderResult == null || !Decimal.TryParse(valueProviderResult.AttemptedValue, out value) ? base.BindModel(controllerContext, bindingContext) : value;

        }
    }
}