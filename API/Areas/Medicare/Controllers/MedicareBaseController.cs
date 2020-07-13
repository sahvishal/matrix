using System;
using System.IO;
using System.Web;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace API.Areas.Medicare.Controllers
{
    public class MedicareBaseController : BaseController
    {

        public MedicareBaseController()
        {
            ValidateToken();

        }

        private void ValidateToken()
        {

            var currentPrivateToken = HttpContext.Current.Request.Headers["Penguin-token"];
            if (string.IsNullOrEmpty(currentPrivateToken))
                throw new Exception("Invalid medicare token.");

            var decryptedToken = currentPrivateToken.Decrypt();
            var userData = decryptedToken.Split('_');
            if (userData.Length != 5)
            {
                throw new InvalidDataException("Invalid medicare token.");
            }
            var sessionId = userData[3];
            var userId = long.Parse(userData[1]);
            var roleId = long.Parse(userData[0]);
            var organizationId = long.Parse(userData[2]);
            var timestamp = userData[4];

            var userloginLogRepository = ApplicationManager.DependencyInjection.Resolve<IUserLoginLogRepository>();
            var currentUserLog = userloginLogRepository.GetCurrentLoggedInLogforUser(userId);
            if (currentUserLog == null) throw new Exception("Invalid medicare token.");

           // if(currentUserLog.)


        }

       
    }
}
