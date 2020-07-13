namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareUserCredentialModel
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public string Npi { get; set; }
        public string Credential { get; set; }
    }
}
