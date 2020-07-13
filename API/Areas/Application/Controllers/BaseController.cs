using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using API.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

namespace API.Areas.Application.Controllers
{
    public abstract class BaseController : ApiController
    {
        internal HttpMethodType MethodType { get; set; }

        protected BaseController()
        {
            ResponseModel = new ResponseModel();
            Logger = IoC.Resolve<ILogManager>().GetLogger("api");
        }

        internal void SetPostResponseModel(HttpMethodType type)
        {
            ResponseModel = new PostResponseModel
            {
                ModelValidation = new ModelValidationOutput { IsValid = true }
            };
            MethodType = type;
        }

        internal void SetResponseModel(HttpMethodType type)
        {
            ResponseModel = new ResponseModel();
            MethodType = type;
        }

        internal ResponseModel ResponseModel { get; private set; }

        protected PostResponseModel PostResponseModel { get { return this.ResponseModel as PostResponseModel; } }

        protected ILogger Logger { get; private set; }

        internal void SetActionArguments(IEnumerable<KeyValuePair<string, object>> actionArguments)
        {
            ResponseModel.Data = actionArguments.Count() == 1 ? actionArguments.First().Value : actionArguments.Select(m => Tuple.Create(m.Key, m.Value)).ToArray();
        }

        internal void SetValidationResult(ModelStateDictionary state)
        {
            var arr = new KeyValuePair<string, ModelState>[state.Values.Count];
            state.CopyTo(arr, 0);

            PostResponseModel.ModelValidation = new ModelValidationOutput
            {
                IsValid = state.IsValid,
                Errors = arr.Where(x => x.Value != null && x.Value.Errors.Any())
                        .Select(x =>
                            new ModelValidationItem(x.Key.IndexOf(".") >= 0 ? x.Key.Substring(x.Key.IndexOf(".") + 1) : x.Key,
                            x.Value.Errors.First().ErrorMessage))
                        .ToList()
            };
        }

        internal ResponseModel SetData(object data)
        {
            ResponseModel.Data = data;
            return ResponseModel;
        }
    }
}