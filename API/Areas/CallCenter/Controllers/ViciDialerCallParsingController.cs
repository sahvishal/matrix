using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Interfaces;
using System;
using System.Web.Http;

namespace API.Areas.CallCenter.Controllers
{
    public class ViciDialerCallParsingController : ApiController
    {
        private readonly ICallUploadService _callUploadService;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _Logger;


        public ViciDialerCallParsingController(ICallUploadService callUploadService, ISessionContext sessionContext, ILogManager logManager)
        {
            _callUploadService = callUploadService;
            _sessionContext = sessionContext;
            _Logger = logManager.GetLogger("ViciDialerCallParsingController");
        }

        [HttpPost]
        public string SaveViciDialerCall([FromBody]ViciDialerCallModel model)
        {
            if (_sessionContext != null && _sessionContext.UserSession != null)
            {
                try
                {
                    _callUploadService.SaveViciDialerCall(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    _Logger.Info("\nCall data is saved for CustomerId: " + model.CustomerId);
                    return "Data saved successfully.";
                }
                catch (Exception ex)
                {
                    _Logger.Error("\nError occurred while saving call data for CustomerId: " + model.CustomerId);
                    _Logger.Error("Message: " + ex.Message);
                    _Logger.Error("StackTrace: " + ex.StackTrace);
                    return "Some error occurred while saving the data. Error: " + ex.Message;
                }
            }
            else
            {
                return "User is not logged in.";
            }
        }
    }
}
