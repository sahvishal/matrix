using System;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels; 

namespace API.Areas.Users.Controllers
{
    [AllowAnonymous]
    public class OnlineLoginController : BaseController
    {
        private readonly ISettings _settings;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempcartService _tempcartService;

        public OnlineLoginController(ISettings settings, IUserLoginRepository userLoginRepository, ICustomerRepository customerRepository, ITempcartService tempcartService)
        {
            _settings = settings;
            _userLoginRepository = userLoginRepository;
            _customerRepository = customerRepository;
            _tempcartService = tempcartService;
        }

        [HttpPost]
        public UserLoginResponseModel ValidateUser(UserLoginModel userLoginModel,string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);

            var model = new UserLoginResponseModel() { RequestValidationModel = onlineRequestValidationModel }; 
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;
            
            if (!ModelState.IsValid)
            {
                throw new Exception("Please enter a valid Username/Password!"); 
            }

            var isValid = _userLoginRepository.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
            if (!isValid)
            {
                GetLoginFailureMessage(userLoginModel); 
            }

            var userLogin = _userLoginRepository.GetByUserName(userLoginModel.UserName);
            var customer = _customerRepository.GetCustomerByUserId(userLogin.Id);
            model = new UserLoginResponseModel { CustomerId = customer.CustomerId, CustomerName = customer.NameAsString, IsValid = true, Message = "", RequestValidationModel = onlineRequestValidationModel };


            return model;
        }

        private void GetLoginFailureMessage(UserLoginModel userLogin)
        {
            try
            {
                var notLoggedInUser = _userLoginRepository.GetByUserName(userLogin.UserName);
                if (notLoggedInUser == null)
                {
                    throw new Exception("Username and/or password do not match. Please try again.");
                }
                //found user but could not login.
                if (notLoggedInUser.Locked)
                {
                    throw new Exception(
                        "Your account has been locked, due to too many attempts. Please contact " +
                        _settings.SupportEmail + " OR call us at " + _settings.PhoneTollFree);
                }

                var loginAttempts = notLoggedInUser.FailedAttempts;
                _userLoginRepository.UpdateLoginStatus(notLoggedInUser.Id, false);

                if (loginAttempts == 1)
                {
                    throw new Exception(
                        "Looks like you are having trouble logging in. You have only 3 more attempts before your " +
                        "account will be temporarily locked for security reasons. Please click on link beside the login button to try and reset your password.");

                }
                if (loginAttempts == 3)
                {
                    throw new Exception(
                        "You have only one attempt left before your account will be temporarily locked " +
                        "for security reasons. Please click on link beside the login button to try and reset your password.");
                }
                if (loginAttempts == 4)
                {
                    throw new Exception(
                        "Your account has been locked, due to too many attempts. Please contact " +
                        _settings.SupportEmail + " OR call us at " + _settings.PhoneTollFree);
                }

                throw new Exception("Username and/or password do not match. Please try again.");
            }
            catch (ObjectNotFoundInPersistenceException<UserLogin>)
            {
                throw new Exception("Username and/or password do not match. Please try again.");
            } 
        }

    }
}
