using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class CancelledCustomerModelFactory : ICancelledCustomerModelFactory
    {
        public CancelledCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, long>> orderIdEventCustomerIdPairs,
            IEnumerable<CustomerCallNotes> notes, IEnumerable<RefundRequest> refundRequests, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<EventAppointmentCancellationLog> appointmentCancellationLogs)
        {
            var model = new CancelledCustomerListModel();
            var cancelledCustomerModels = new List<CancelledCustomerModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = eventListModel.Collection.Where(e => e.EventCode == ec.EventId).FirstOrDefault();

                var customer = customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();

                var order = orders.Where(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId).FirstOrDefault();

                var scheduledBy = ec.DataRecorderMetaData.DataRecorderCreator.Id == ec.CustomerId ? "Self" : idNamePairs.Where(p => p.FirstValue == ec.DataRecorderMetaData.DataRecorderCreator.Id).First().SecondValue;

                var cancellationReason = "N/A";
                var canceledDate = string.Empty;
                var subReason = string.Empty;

                if (!appointmentCancellationLogs.IsNullOrEmpty())
                {
                    var customerLog = appointmentCancellationLogs.OrderByDescending(x => x.DateCreated).FirstOrDefault(x => x.EventCustomerId == ec.Id);
                    canceledDate = customerLog != null ? customerLog.DateCreated.ToShortDateString() : "N/A";
                    if (customerLog != null)
                    {
                        cancellationReason = ((CancelAppointmentReason)customerLog.ReasonId).GetDescription();
                        if (customerLog.SubReasonId.HasValue && customerLog.SubReasonId.Value > 0)
                            subReason = ((CancelAppointmentSubReason)customerLog.SubReasonId).GetDescription();
                    }

                }


                var cancelledBy = string.Empty;
                IEnumerable<RefundRequest> requests = null;
                if (refundRequests != null)
                    requests = refundRequests.Where(rr => rr.OrderId == order.Id).Select(rr => rr).ToArray();
                var totalAmount = 0.00m;
                if (order != null)
                {
                    if (order.OrderDetails.Where(od => od.IsCompleted).Any() && requests != null)
                    {
                        totalAmount = order.DiscountedTotal;
                        cancelledBy = idNamePairs.Where(p => p.FirstValue == requests.Last().RequestedByOrgRoleUserId).First().SecondValue;
                    }
                    else
                    {
                        var orderDetails = order.OrderDetails.OrderByDescending(od => od.Id).ToList();
                        cancelledBy = idNamePairs.Where(p => p.FirstValue == orderDetails.First().DataRecorderMetaData.DataRecorderCreator.Id).First().SecondValue;

                        foreach (var orderDetail in orderDetails)
                        {
                            if (orderDetail.Price > 0)
                                break;
                            totalAmount += (-1) * orderDetail.Price;
                        }
                    }
                }

                var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.Where(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id).FirstOrDefault());

                var agentRole = string.Empty;
                if (registeredBy != null)
                {

                    agentRole = registeredBy.RoleId == (long)Roles.Customer ? "Internet" : roles.Where(r => r.Id == registeredBy.RoleId).FirstOrDefault().DisplayName;
                }

                var sponsorName = eventModel.EventType.ToLower() == EventType.Corporate.ToString().ToLower() ? eventModel.CorporateAccount : eventModel.HospitalPartner;

                var cancelledCustomerModel = new CancelledCustomerModel()
                {
                    Address = customer.Address,
                    CustomerId = ec.CustomerId,
                    CustomerName = customer.NameAsString,
                    DateofBirth = customer.DateOfBirth,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    EventId = eventModel.EventCode,
                    EventDate = eventModel.EventDate,
                    Pod = eventModel.Pod,
                    Gender = customer.Gender.ToString(),
                    Host = eventModel.Location,
                    HostAddress = eventModel.Address,
                    PhoneBusiness = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                    PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                    AdSource = ec.MarketingSource,
                    PhoneOfficeExtension = customer.PhoneOfficeExtension,
                    OrderId = orderIdEventCustomerIdPairs.Where(oe => oe.SecondValue == ec.Id).Select(oe => oe.FirstValue).FirstOrDefault(),
                    TotalAmount = totalAmount,
                    ScheduledBy = scheduledBy,
                    CancelledBy = cancelledBy,
                    SignUpMethod = agentRole,
                    CancellationReason = cancellationReason,
                    Notes = notes.Where(n => n.CustomerId == ec.CustomerId && n.EventId == ec.EventId).ToArray(),
                    CanceledDate = canceledDate,
                    SponsoredBy = sponsorName,
                    SubReason = subReason,
                };


                if (requests.Count() > 0)
                {
                    var modelNotes = cancelledCustomerModel.Notes.ToList();
                    foreach (var refundRequest in requests)
                    {
                        modelNotes.Add(new CustomerCallNotes
                                                {
                                                    Notes = refundRequest.Reason,
                                                    NotesType = CustomerRegistrationNotesType.CancellationNote,
                                                    DataRecorderMetaData = new DataRecorderMetaData(refundRequest.RequestedByOrgRoleUserId, refundRequest.RequestedOn, null)
                                                });

                        //if (refundRequest.IsResolved && refundRequest.RefundRequestResult != null)
                        //    modelNotes.Add(new CustomerCallNotes
                        //                            {
                        //                                Notes = refundRequest.RefundRequestResult.Notes,
                        //                                NotesType = CustomerRegistrationNotesType.CancellationNote,
                        //                                DataRecorderMetaData = new DataRecorderMetaData(refundRequest.RefundRequestResult.ProcessedByOrgRoleUserId, refundRequest.RefundRequestResult.ProcessedOn, null)
                        //                            });

                    }
                    cancelledCustomerModel.Notes = modelNotes;
                }
                cancelledCustomerModels.Add(cancelledCustomerModel);
            });
            model.Collection = cancelledCustomerModels;
            return model;
        }
    }
}
