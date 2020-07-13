namespace Falcon.App.Core.Medicare.Enum
{
    public sealed class MedicareApiUrl
    {
        public const string AuthenticationUrl = "Ehr/Ehr/AuthenticateEhrToken";
        public const string EventInfoUpdateUrl = "Ehr/Ehr/UpdateEventInfo";
        public const string UpdateVisitStatus = "Ehr/Ehr/UpdateVisitStatus";
        public const string GetPatientTestForEhr = "Ehr/Ehr/GetPatientTestForEhr";
        public const string CreateUpdateUserForEhr = "Ehr/Ehr/CreateUpdateUser";
        public const string AuthenticateUser = "Ehr/Ehr/AuthenticateUser";
        public const string UnlockPatient = "Ehr/Ehr/Unlock";
        public const string CreateUpdateCustomer = "Ehr/Ehr/CreateUpdateCustomer";
        public const string CreateUpdateSite = "Ehr/Ehr/CreateUpdateSite";
        public const string SaveCheckList = "Ehr/Ehr/SaveCheckList";
        public const string UpdateCustomerResult = "Ehr/Ehr/UpdateCustomerResult";
        public const string UpdateCustomerKynResult = "Ehr/Ehr/UpdateCustomerKynResult";
        public const string SyncUserCredentials = "Ehr/Ehr/SyncUserCredentials";
        public const string SyncEventTest = "Ehr/Ehr/SyncEventTest";
        public const string SyncRaps = "Ehr/Ehr/SyncRaps";
        public const string MergeCustomer = "Ehr/Ehr/MergeCustomer";
        public const string SyncMedication = "Ehr/Ehr/SyncMedication";
        public const string SyncSuspectCondition = "Ehr/Ehr/SyncSuspectCondition";

        //for Hip in Medicare
        public const string SetEhrToken = "Ehr/Ehr/SetEhrToken";

        //Result Flow Url
        public const string ToggleCanUnSignForVisit = "Ehr/Ehr/ToggleCanUnSignForVisit";
        public const string ToggleReadyForCodingForVisit = "Ehr/Ehr/ToggleReadyForCodingForVisit";
        public const string ReadyForReEvaluation = "Ehr/Ehr/ReadyForReEvaluation";

        public const string ActivateDeactivateUser = "Ehr/Ehr/ActivateDeactivateUser";

        public const string AssignedNursePractitionerDetails = "Ehr/Ehr/AssignedNursePractitionerDetails";

    }
}
