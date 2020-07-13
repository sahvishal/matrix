using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface IPrintOrderItemReposistory
    {
        bool UpdatePrintOrderItemStatus(long printOrderItemId, ItemStatus itemStatus);

        List<string> ConfirmPrintOrderItemStatusByHsc(string confirmeByName, DateTime confirmationDate,
                                                      string sourceCode, OrganizationRoleUser statusUpdatedBy);


        List<string> ConfirmPrintOrderItemStatusByCallCenter(string confirmeByName, DateTime confirmationDate,
                                                            string sourceCode, OrganizationRoleUser statusUpdatedBy);


        List<string> ConfirmPrintOrderItemStatusByEmail(string confirmeByName, DateTime confirmationDate,
                                                string sourceCode);

        List<string> ConfirmPrintOrderItemStatusByUniqueUrl(string confirmeByName, DateTime confirmationDate,
                                                    string sourceCode);


        List<string> ConfirmPrintOrderItemStatus(string confirmeByName, DateTime confirmationDate,
                                                string sourceCode, OrganizationRoleUser statusUpdatedBy,
                                                long confirmationMode);


        void ConfirmPrintOrderStatus(string sourceCode);

        Boolean SourceCodeAssociatedForPrintOrderItem(string sourceCode);


        List<PrintOrderItemViewData> GetPrintOrderItemDetail(long printOrderId);

        Boolean IsPrintOrderItemEditable(long eventCampaignId);

        Boolean IsAdvocateHaveAssignedPrintOrderItem(long advocateId, long eventId);

        OrderedPair<string, string> GetPrintOrderItemAdvocate(long printOrderItemId);

        string GetPrintOrderPdfPathForEventCampaign(Int64 eventCampaignId);


    }
}