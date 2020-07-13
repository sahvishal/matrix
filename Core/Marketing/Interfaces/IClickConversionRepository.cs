namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IClickConversionRepository
    {
        void SaveProspectConversion(long clickId, long prospectCustomerId);        
        void SaveEventCustomerConversion(long prospectCustomerId, long eventEventCustomerId);
        void SaveCustomerConversion(long prospectCustomerId, long customerId);
    }
}