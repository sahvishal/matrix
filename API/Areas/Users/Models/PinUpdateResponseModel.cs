
namespace API.Areas.Users.Models
{
    public class PinUpdateResponseModel
    {
        public int RemainingDays { get; set; }

        public int ShowAlertBeforePinExpirationInDays { get; set; }
    }
}