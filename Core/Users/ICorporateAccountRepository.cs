using System.Collections.Generic;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICorporateAccountRepository
    {
        CorporateAccount SaveAccount(CorporateAccount corporateAccount, IEnumerable<long> shippingOptionIds, IEnumerable<long> accountCustomerResultTestDependency, IEnumerable<long> accountPcpResultTestDependency,
            IEnumerable<long> healthPlanResultTestDependency);

        IEnumerable<CorporateAccount> GetbyFilter(int pageNumber, int pageSize, CorporateAccountListModelFilter filter,
                                                  out int totalRecords);
        IEnumerable<OrderedPair<long, string>> GetAccountPackagesNameIdPair(long accountId);
        IEnumerable<OrderedPair<long, string>> GetAccountIdPackagesNamePair(long[] accountIds);
        CorporateAccount GetByUrlSiffix(string urlSuffix);
        bool UpdateConvertedHost(long accountId, long? hostId);
        IEnumerable<OrderedPair<long, string>> GetEventIdCorporateAccountNamePair(IEnumerable<long> eventIds);
        IEnumerable<CorporateAccount> GetAll();
        bool AccountCodeExists(long excludedAccountId, string accountCode);
        IEnumerable<OrderedPair<long, long>> GetEventIdCorporateAccountPairForSponsoredBy(IEnumerable<long> eventIds);
        CorporateAccount GetbyEventId(long eventId);
        IEnumerable<long> GetAccountShippingOptionIds(long accountId);
        IEnumerable<CorporateAccount> GetByIds(IEnumerable<long> ids);
        CorporateAccount GetForEventIdWithOrganizationDetail(long eventId);
        bool CustomerTagExists(long excludedAccountId, string customerTag);
        CorporateAccount GetByTag(string tag);
        IEnumerable<long> GetAccountCustomerResultTestDependency(long accountId);
        IEnumerable<long> GetAccountPcpResultTestDependency(long accountId);
        bool CheckCanChangeClinicalTemplate(long id);
        IEnumerable<CorporateAccount> GetByTags(string[] tags);
        IEnumerable<CorporateAccount> GetCorporateAccountForLockEvent();
        IEnumerable<long> GetAccountHealthPlanResultTestDependency(long accountId);
        IEnumerable<CorporateAccount> GetAllHealthPlan();
        void SaveAccountAddtionalFieldDependency(long accountId, IEnumerable<AccountAdditionalFields> accountAdditionalFields);

        IEnumerable<CorporateAccount> GetHealthPlanbyFilter(int pageNumber, int pageSize, HealthPlanRevenueListModelFilter filter, out int totalRecords);
        IEnumerable<CorporateAccount> GetAllOnlyCorporateAccount();
        bool IsCorporateAccount(long accountId);

        IEnumerable<CorporateAccount> GetAllHealthPlansForPrintAceAndMip();
        IEnumerable<string> GetHealthPlanTags();
        IEnumerable<CorporateAccount> GetByChecklistTemplateIds(IEnumerable<long> checklistTemplateIds);
        IEnumerable<OrderedPair<long, string>> HealthPlanNamesCorrepondingToHealthPlanIds(IEnumerable<long?> healthPlanIds);

        long GetHealthPlanIdByAccountName(string accountName);
        IEnumerable<CorporateAccount> GetHealthPlanAssingedToAgent(long agentOrganizationId);

        IEnumerable<OrderedPair<long, string>> GetRestrictionIdNamePairs(long[] healthPlanIds);
        IEnumerable<CorporateAccount> GetAllCorporateAccountToSendPatientDataToAces();
        IEnumerable<CorporateAccount> GetAllCorporateAccountToSendConsentData();
        IEnumerable<OrderedPair<string, string>> HealthPlanNamesCorrepondingToTag(string[] tags);
        IEnumerable<CorporateAccount> GetCorporateAccountbyClientIds(string[] clientIds);
        bool AcesToHipIntakeShortNameExists(long excludedAccountId, string acesToHipIntakeShortName);

        IEnumerable<CorporateAccount> GetAllCorporateAccountAcestoHipInTake();

        IEnumerable<CorporateAccount> GetByFluConsentTemplateIds(IEnumerable<long> templateIds);

        CorporateAccount GetByTagWithOrganization(string tag);

        IEnumerable<CorporateAccount> GetBySurveyTemplateIds(IEnumerable<long> surveyTenplateIds);
    }
}