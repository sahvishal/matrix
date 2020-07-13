namespace Falcon.App.Core.Medical
{
    public interface IAttestationFormService
    {string PrintAttestationPdf(long accountId, long customerId, long eventId);
    }
}
