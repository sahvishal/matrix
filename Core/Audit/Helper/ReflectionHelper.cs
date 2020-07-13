using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Type = System.Type;

namespace Falcon.App.Core.Audit.Helper
{
    public class ReflectionHelper
    {
        public static bool IsListModel(dynamic model)
        {
            var type = (Type)model.GetType();
            var modelName = (string)model.GetType().Name;
            if (modelName.Contains("ListModel") || model.GetType() == typeof(PagingModel) || modelName.EndsWith("ListModel") || (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IEnumerable<>) || type.GetGenericTypeDefinition() == typeof(List<>))) || type.IsArray)
            {
                return true;
            }

            return false;
        }

        public static ModelType GetModelType(dynamic model)
        {
            var modelName = (string)model.GetType().Name;

            if (IsListModel(model))
                return ModelType.List;

            if (model is EventCustomersFindingEditModel)
                return ModelType.List;

            if (modelName.Contains("EditModel") || modelName.EndsWith("EditModel"))
                return ModelType.Edit;
            if (modelName.Contains("ViewModel") || modelName.EndsWith("ViewModel"))
                return ModelType.View;

            return ModelType.Other;

        }
    }
}
