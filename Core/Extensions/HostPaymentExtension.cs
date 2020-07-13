using System.Collections.Generic;
using System.Linq;
using System;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Extensions
{
    public static class HostPaymentExtension
    {
        public static List<EventHostDepositViewData> HostPaymentViewData(this IEnumerable<HostPayment> hostPayments, IEnumerable<Event> events, IEnumerable<Host> hosts)
        {
            var eventHostDepositViewDatas = new List<EventHostDepositViewData>();

            foreach (var hostPayment in hostPayments)
            {
                if (hostPayment != null)
                {
                    HostPayment payment = hostPayment;

                    var currentEvent = events.SingleOrDefault(e => e.Id == payment.EventId);
                    var host = hosts.SingleOrDefault(h => h.Id == payment.HostId);

                    if (host != null && currentEvent != null)
                    {
                        var eventHostDepositViewData = new EventHostDepositViewData
                        {
                            IsDeposit = false,
                            EventId = hostPayment.EventId,
                            EventDate = currentEvent.EventDate,
                            EventStatus = currentEvent.Status,
                            TaxIdNumber =
                                !string.IsNullOrEmpty(host.TaxIdNumber)
                                    ? host.TaxIdNumber
                                    : string.Empty,
                            Name = currentEvent.Name,
                            EventStreetAddressLine1 = host.Address.StreetAddressLine1,
                            EventStreetAddressLine2 = host.Address.StreetAddressLine2,
                            EventCity = host.Address.City,
                            EventState = host.Address.State,
                            EventZip = host.Address.ZipCode!=null ? host.Address.ZipCode.Zip:string.Empty,
                            EventCountry = host.Address.Country,
                            HostId = hostPayment.HostId,
                            Amount = hostPayment.Amount,
                            PaymentMode = hostPayment.PaymentMode,
                            DueDate = hostPayment.DueDate,
                            PayableTo = hostPayment.PayableTo,
                            MailingAttentionOf = hostPayment.MailingAttentionOf,
                            MailingOrganizationName =
                                hostPayment.MailingOrganizationName,
                            AddressId = hostPayment.PaymentMailingAddress.Id,
                            StreetAddressLine1 =
                                hostPayment.PaymentMailingAddress.StreetAddressLine1,
                            StreetAddressLine2 =
                                hostPayment.PaymentMailingAddress.StreetAddressLine2,
                            City = hostPayment.PaymentMailingAddress.City,
                            State = hostPayment.PaymentMailingAddress.State,
                            Zip = hostPayment.PaymentMailingAddress.ZipCode != null ? hostPayment.PaymentMailingAddress.ZipCode.Zip : string.Empty,
                            Country = hostPayment.PaymentMailingAddress.Country,
                            Status = hostPayment.Status,
                            IsActive = hostPayment.IsActive,
                            Id = hostPayment.Id,
                            HostPaymentTransactions =
                                hostPayment.HostPaymentTransactions
                        };
                        eventHostDepositViewDatas.Add(eventHostDepositViewData);
                    }
                }
            }
            return eventHostDepositViewDatas;
        }

        public static List<EventHostDepositViewData> HostDepositViewData(this IEnumerable<HostDeposit> hostDeposits, IEnumerable<Event> events, IEnumerable<Host> hosts)
        {
            var eventHostDepositViewDatas = new List<EventHostDepositViewData>();

            foreach (var hostDeposit in hostDeposits)
            {
                if (hostDeposit != null)
                {
                    HostDeposit deposit = hostDeposit;

                    var currentEvent = events.SingleOrDefault(e => e.Id == deposit.EventId);
                    var host = hosts.SingleOrDefault(h => h.Id == deposit.HostId);

                    if (host != null && currentEvent != null)
                    {
                        var eventHostDepositViewData = new EventHostDepositViewData
                        {
                            IsDeposit = true,
                            EventId = hostDeposit.EventId,
                            EventDate = currentEvent.EventDate,
                            EventStatus = currentEvent.Status,
                            TaxIdNumber =
                                !string.IsNullOrEmpty(host.TaxIdNumber)
                                    ? host.TaxIdNumber
                                    : string.Empty,
                            Name = events.Single(e => e.Id == deposit.EventId).Name,
                            EventStreetAddressLine1 = host.Address.StreetAddressLine1,
                            EventStreetAddressLine2 = host.Address.StreetAddressLine2,
                            EventCity = host.Address.City,
                            EventState = host.Address.State,
                            EventZip = host.Address.ZipCode!=null ? host.Address.ZipCode.Zip:string.Empty,
                            EventCountry = host.Address.Country,
                            HostId = hostDeposit.HostId,
                            Amount = hostDeposit.Amount,
                            PaymentMode = hostDeposit.PaymentMode,
                            DueDate = hostDeposit.DueDate,
                            PayableTo = hostDeposit.PayableTo,
                            MailingAttentionOf = hostDeposit.MailingAttentionOf,
                            MailingOrganizationName =
                                hostDeposit.MailingOrganizationName,
                            AddressId = hostDeposit.PaymentMailingAddress.Id,
                            StreetAddressLine1 =
                                hostDeposit.PaymentMailingAddress.StreetAddressLine1,
                            StreetAddressLine2 =
                                hostDeposit.PaymentMailingAddress.StreetAddressLine2,
                            City = hostDeposit.PaymentMailingAddress.City,
                            State = hostDeposit.PaymentMailingAddress.State,
                            Zip = hostDeposit.PaymentMailingAddress.ZipCode!=null ?hostDeposit.PaymentMailingAddress.ZipCode.Zip:string.Empty,
                            Country = hostDeposit.PaymentMailingAddress.Country,
                            Status = hostDeposit.Status,
                            IsActive = hostDeposit.IsActive,
                            Id = hostDeposit.Id,
                            DepositFullRefundDueDays =
                                hostDeposit.DepositFullRefundDueDays > 0
                                    ? (int)hostDeposit.DepositFullRefundDueDays
                                    : 0,
                            DepositFullRefundDueDate =
                                hostDeposit.DepositFullRefundDueDays > 0
                                    ? events.Single(e => e.Id == deposit.EventId).
                                          EventDate.AddDays(
                                          (long)
                                          -hostDeposit.DepositFullRefundDueDays)
                                    : (DateTime?)null,
                            DepositApplicablityMode =
                                hostDeposit.DepositApplicablityMode,
                            HostPaymentTransactions =
                                hostDeposit.HostPaymentTransactions
                        };
                        eventHostDepositViewDatas.Add(eventHostDepositViewData);
                    }
                }
            }
            return eventHostDepositViewDatas;
        }

    }
}