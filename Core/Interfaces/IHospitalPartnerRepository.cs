using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface IHospitalPartnerRepository
    {
        List<OrderedPair<long, string>> GetIdNamePairsforHospitalPartners();
        HospitalPartner GetHospitalPartnerforaVendor(long medicalVendorId);
        void Delete(long hospitalPartnerId);
        void DeleteHospitalPartnerPackage(long hospitalPartnerId);
        void DeleteHospitalPartnerTerritory(long hospitalPartnerId);
        long Save(HospitalPartner hospitalPartner);
        void SaveHospitalPartnerPackage(long hospitalPartnerId, IEnumerable<long> packageIds);
        void SaveHospitalPartnerTerritory(long hospitalPartnerId, IEnumerable<long> territoryIds);
        IEnumerable<long> GetEventIdsForHospitalPartner(long hospitalPartnerId);
        IEnumerable<OrderedPair<long, long>> GetEventAndHospitalPartnerOrderedPair(IEnumerable<long> eventIds);
        long GetHospitalPartnerIdForEvent(long eventId);
        IEnumerable<OrderedPair<long, string>> GetHospitalPartnerCustomerStatus();
        Notes SaveHospitalPartnerEventNotes(long eventId, Notes notes);
        IEnumerable<Notes> GetHospitalPartnerEventNotes(long eventId);
        IEnumerable<OrderedPair<long, long>> GetEventIdNotesIdPair(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, string>> GetHospitalPartnerCustomerOutcome();
        IEnumerable<long> GetAttachedHospitalMaterialEventIdsForHospitalPartner(long hospitalPartnerId);
        IEnumerable<EventHospitalPartner> GetEventHospitalPartnersByEventIds(IEnumerable<long> eventIds);
        List<OrderedPair<long, string>> GetIdNamePairsforParentHospitalPartners();
        EventHospitalPartner GetEventHospitalPartnersByEventId(long eventId);
        IEnumerable<OrderedPair<long, string>> GetEventIdHospitalPartnerNamePair(IEnumerable<long> eventIds);
    }
}