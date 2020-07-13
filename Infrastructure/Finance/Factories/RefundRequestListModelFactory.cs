using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class RefundRequestListModelFactory : IRefundRequestListModelFactory
    {
        public RefundRequestListModel Create(IEnumerable<RefundRequest> requests, IEnumerable<Customer> customers, IEnumerable<Event> events, IEnumerable<Host> hosts,
            IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<Role> roles, IEnumerable<Order> orders,
            IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentCancellationLog> appointmentCancellationLogs)
        {
            var model = new RefundRequestListModel();
            var basicModels = new RefundRequestBasicInfoModel[requests.Count()];

            int index = 0;
            foreach (var request in requests)
            {
                var requestCustomer = customers.Where(c => c.CustomerId == request.CustomerId).SingleOrDefault();
                var requestCustomerEvent = events.Where(e => e.Id == request.EventId).SingleOrDefault();
                var host = hosts.Where(h => h.Id == requestCustomerEvent.HostId).SingleOrDefault();
                var idNamePair = idNamePairs.Where(p => p.FirstValue == request.RequestedByOrgRoleUserId).FirstOrDefault();
                var orgRoleUser = orgRoleUsers.Where(oru => oru.Id == request.RequestedByOrgRoleUserId).FirstOrDefault();
                var role = roles.Where(r => r.Id == orgRoleUser.RoleId).SingleOrDefault();

                OrderedPair<long, string> processedByidNamePair = null;
                Role processedByRole = null;
                if (request.RefundRequestResult != null && request.RefundRequestResult.ProcessedByOrgRoleUserId > 0)
                {
                    processedByidNamePair = idNamePairs.Where(p => p.FirstValue == request.RefundRequestResult.ProcessedByOrgRoleUserId).FirstOrDefault();

                    orgRoleUser = orgRoleUsers.Where(oru => oru.Id == request.RefundRequestResult.ProcessedByOrgRoleUserId).FirstOrDefault();

                    processedByRole = roles.Where(r => r.Id == orgRoleUser.RoleId).SingleOrDefault();
                }

                var cancellationReason = "N/A";
                var subReason = string.Empty;

                if (!eventCustomers.IsNullOrEmpty() && !appointmentCancellationLogs.IsNullOrEmpty())
                {
                    var cancellationLogs = (from acl in appointmentCancellationLogs
                                            join ec in eventCustomers on acl.EventCustomerId equals ec.Id
                                            where ec.EventId == request.EventId && ec.CustomerId == request.CustomerId && request.RequestedOn.AddMinutes(2) > acl.DateCreated && request.RequestedOn.AddMinutes(-2) < acl.DateCreated
                                            select acl).FirstOrDefault();

                    if (cancellationLogs != null)
                    {
                        cancellationReason = ((CancelAppointmentReason)cancellationLogs.ReasonId).GetDescription();
                        if (cancellationLogs.SubReasonId.HasValue && cancellationLogs.SubReasonId.Value > 0)
                            subReason = ((CancelAppointmentSubReason)cancellationLogs.SubReasonId).GetDescription();
                    }
                }

                var order = orders.Single(o => o.Id == request.OrderId);

                var bookedByidNamePair = idNamePairs.First(p => p.FirstValue == order.DataRecorderMetaData.DataRecorderCreator.Id);
                orgRoleUser = orgRoleUsers.First(oru => oru.Id == order.DataRecorderMetaData.DataRecorderCreator.Id);
                var bookedByRole = roles.Where(r => r.Id == orgRoleUser.RoleId).Single();

                var basicModel = new RefundRequestBasicInfoModel
                                     {
                                         CustomerId = request.CustomerId,
                                         EventId = request.EventId,
                                         OrderId = request.OrderId,
                                         RequestId = request.Id,
                                         ReasonforRefund = request.Reason,
                                         RefundRequestType = request.RefundRequestType,
                                         EventDate = requestCustomerEvent != null ? (DateTime?)requestCustomerEvent.EventDate : null,
                                         HostAddress = host.Address,
                                         HostName = host.OrganizationName,
                                         CustomerName = requestCustomer != null ? requestCustomer.NameAsString : string.Empty,
                                         RequestedRefundAmount = request.RequestedRefundAmount,
                                         RequestedOn = request.RequestedOn,
                                         RequestedBy = idNamePair.SecondValue,
                                         RequestedByRole = role.DisplayName,
                                         BookedBy = bookedByidNamePair.SecondValue,
                                         BookedByRole = bookedByRole.Id == (long)Roles.Customer ? "Self" : bookedByRole.DisplayName,
                                         Status = (RequestStatus)request.RequestStatus,
                                         RequestProcessedBy = processedByidNamePair != null ? processedByidNamePair.SecondValue : string.Empty,
                                         RequestProcessedByRole = processedByRole != null ? processedByRole.DisplayName : string.Empty,
                                         RequestProcessedOn = request.RefundRequestResult != null ? (DateTime?)request.RefundRequestResult.ProcessedOn : null,
                                         RequestProcessedNotes = request.RefundRequestResult != null ? request.RefundRequestResult.Notes : string.Empty,
                                         RequestResultType = request.RefundRequestResult != null ? (RequestResultType?)request.RefundRequestResult.RequestResultType : null,
                                         CancellationReason = cancellationReason,
                                         SubReason = subReason,
                                     };

                basicModels[index++] = basicModel;
            }

            model.Collection = basicModels;
            return model;
        }
    }
}