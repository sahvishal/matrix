using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.Data.EntityClasses;

namespace Falcon.Web.Infrastructure.Marketing.Interfaces
{
    public interface IProspectCustomerViewDataFactory
    {
        List<ProspectCustomerViewData> CreateViewDataforHSC
            (
            List<OrderedPair<long, string>> prospectIdSourceCodePair,
            List<OrderedPair<long, string>> seminarIdSourceCodePair,
            List<OrderedPair<long, long>> callIdProspectIdPair,
            List<ProspectCustomerEntity> prospectsCustomerEntity,
            List<EventsEntity> eventsEntity,
            List<CallsEntity> callsEntity
            );

        List<ProspectCustomerViewData> CreateViewDataForCallCenterRep(List<ProspectCustomerEntity> listProspectCustomer,
            List<OrderedPair<SeminarsEntity, long>> listSeminarSourceCodePair,
            List<OrderedPair<long, string>> listSourceCodeIdpair);
    }
}