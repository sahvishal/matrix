using System;
using System.Web.Http;
using API.Areas.Users.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.ViewModels;

namespace API.Areas.Users.Controllers
{
   
    public class PatientController : ApiController
    {
        private readonly IPatientProfileUpdateService _patientProfileUpdateService;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;
        public PatientController(ILogManager logManager, IPatientProfileUpdateService patientProfileUpdateService, ISessionContext sessionContext)
        {
            _patientProfileUpdateService = patientProfileUpdateService;
            _sessionContext = sessionContext;
            _logger = logManager.GetLogger<PatientController>();
        }


        [HttpPost]
        public ResponseBaseModel SavePatient([FromBody]Patient patient)
        {
            var model = new ResponseBaseModel { IsSuccess = false };
            try
            {
                _patientProfileUpdateService.Save(patient, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.IsSuccess = true;
                model.Message = "updated successfully";
            }
            catch (InvalidAddressException exception)
            {
                var msg = string.Format("Invalid Address or Email Address Message {0} \n stack trace: {1}", exception.Message, exception.StackTrace);
                _logger.Error(msg);
                model.Message = exception.Message;
            }
            catch (DuplicateObjectException<ZipCode> exception)
            {
                var msg = string.Format("Zip code Error {0} \nstack trace:  {1}", exception.Message, exception.StackTrace);
                _logger.Error(msg);
                model.Message = "Zip code has some problem";
            }
            catch (Exception exception)
            {
                var msg = string.Format("while saving Patient Message {0} \n stack trace:  {1}", exception.Message, exception.StackTrace);
                _logger.Error(msg);
                model.Message = exception.Message;
            }
            return model;
        }

        [HttpGet]
        public MobileResponseModel GetPatients([FromUri]PatientSearchFilter filter)
        {
            try
            {
                var technicianId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var data = _patientProfileUpdateService.GetPatients(filter, technicianId);

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error occurred while searching patients : {0}", ex.Message)
                };
            }
        }

        [HttpGet]
        public MobileResponseModel GetPatientDetail(long eventCustomerId)
        {
            try
            {
                var data = _patientProfileUpdateService.GetPatientDetail(eventCustomerId);

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new MobileResponseModel
                {
                    IsSuccess = false,
                    Message = string.Format("Error occurred while getting patient detail for EventCustomerId : {0}. Message : {1}", eventCustomerId, ex.Message)
                };
            }
        }
    }
}
