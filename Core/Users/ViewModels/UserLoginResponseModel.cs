 using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserLoginResponseModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }

    }
}
