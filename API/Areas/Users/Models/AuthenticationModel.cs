namespace API.Areas.Users.Models
{
    public class AuthenticationModel
    {
        public long UserId { get; set; }

        public string Token { get; set; }

        public int AttemptCount { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Pin { get; set; }

        public int RemainingDays { get; set; }

        public int ShowAlertBeforePinExpirationInDays { get; set; }
    }
}