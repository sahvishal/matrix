using System.Collections.Generic;
using System.Data;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling
{
    public interface ICorporateUploadHelper
    {
        IEnumerable<MassRegistrationEditModel> GetRegistraionModels(string fileName);
        MassRegistrationEditModel GetRegistrationEditModel(DataRow row, IEnumerable<State> states, IEnumerable<Country> countries, long eventId, List<long> selectedAppointmentIds);
        void SetDropDownInfo(MassRegistrationListModel model);
        void SetEventDetails(MassRegistrationListModel model);
        string CheckAddtionalField(CorporateCustomerEditModel customerEditModel, IEnumerable<AccountAdditionalFieldsEditModel> accountAdditionalFieldEditModel);
        long FailedCustomerCount(string failedCustomerFilePath, MediaLocation mediaLocation);
        void CreateHeaderFileRecord(string filePath, DataTable dataTable);
        CorporateCustomerEditModel GetCorporateCustomerEditModel(DataRow row);
        // IEnumerable<string> GetPreApprovedTests(DataRow row, string fieldName);
        //IEnumerable<string> GetCurrentMedication(DataRow row, string fieldName);
        //IEnumerable<string> GetIcdCodesTests(DataRow row, string fieldName);
        void UpdateFailedRecords(string filePath, IEnumerable<CorporateCustomerEditModel> failedCustomers);
        string CheckIsFileContainsRecord(bool isParseSucceded, MediaLocation mediaLocation, string filePath);
        void CreateHeaderAdjustOrderForEventCustoerRecord(string filePath);
        void UpdateAdjustOrderRecords(string filePath, IEnumerable<EventCusomerAdjustOrderViewModel> model);
        string CheckAllColumnExist(string[] columns);
        string CheckAllEligibilityColumnExist(string[] givenList);

        CorporateCustomerEditModel GetMemberUploadbyAcesCustomerEditModel(DataRow row);
        string CheckAllMemberUploadbyAcesColumnExist(string[] columnList);

        void UpdateMemberUploadbyAcesFailedCustomerRecords(string filePath, IEnumerable<MemberUploadbyAcesFailedCustomerModel> failedCustomers);

        string CheckAllCustomerEligibilityUploadColumnExist(string[] columnList);
        string CheckForMissingColumnInCustomerActivityTypeUpload(string[] columnList);

        IEnumerable<long> RemoveFocFromPreApprovedTest(List<long> preApprovedTestIds);
    }
}
