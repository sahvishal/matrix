using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ILeadResultPdfHelper
    {
        void LoadLeadTestresults(HtmlDocument doc, LeadTestResult testResult, bool removeLongDescription, List<OrderedPair<long, string>> technicianIdNamePairs, bool loadImages, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview,
            DateTime eventDate, bool isPhysicianPartnerCustomer);
    }
}
