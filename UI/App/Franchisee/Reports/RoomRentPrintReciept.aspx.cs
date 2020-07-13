using System;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using System.Collections.Generic;

namespace Falcon.App.UI.App.Franchisee.Reports
{
    public partial class RoomRentPrintReciept : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventId"] != null)
            {
                long eventId = 0;
                long.TryParse(Request.QueryString["EventId"], out eventId);
                IHostDepositService hostDepositService = new HostDepositService();
                long totalRecord = 0;
                List<EventHostDepositViewData> eventHostDepositViewData
                    = hostDepositService.GetHostDepositsByFilters(
                        eventId, null, null, null, null, 1, 2, out totalRecord);

                if (eventHostDepositViewData != null && eventHostDepositViewData.Count > 0)
                    SetHostPaymentData(eventHostDepositViewData);
            }
        }

        private void SetHostPaymentData(IEnumerable<EventHostDepositViewData> eventHostDepositViewData)
        {
            //const string notApplicable = "N/A";
            var eventHostPaymentData = eventHostDepositViewData.Single(ehpd => !ehpd.IsDeposit);
            _lblHostingEventCost.InnerText = eventHostPaymentData.Amount.ToString("0.00");
            _lblTaxId.InnerText = eventHostPaymentData.TaxIdNumber;
            _lblPaymentMethod.InnerText = eventHostPaymentData.PaymentMode == HostPaymentType.Both
                                              ? HostPaymentType.Check + " " + HostPaymentType.CreditCard
                                              : eventHostPaymentData.PaymentMode.ToString();
            _lblPaymentDueDate.InnerText = eventHostPaymentData.DueDate.HasValue
                                               ? eventHostPaymentData.DueDate.Value.ToShortDateString()
                                               : string.Empty;
            _lblPaymentPayableTo.InnerText = eventHostPaymentData.PayableTo;
            _lblPaymentAttentionOf.InnerText = eventHostPaymentData.MailingAttentionOf;
            _lblPaymentOrganizationName.InnerText = eventHostPaymentData.MailingOrganizationName;
            _lblPaymentAddress.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(CommonCode.AddressMultiLine(eventHostPaymentData.EventStreetAddressLine1,
                                                                       eventHostPaymentData.EventStreetAddressLine2,
                                                                       eventHostPaymentData.EventCity,
                                                                       eventHostPaymentData.EventState,
                                                                       eventHostPaymentData.EventZip), true);

            var eventHostDepositData = eventHostDepositViewData.SingleOrDefault(ehpd => ehpd.IsDeposit);
            if (eventHostDepositData != null)
            {
                _lblIsDepositRequired.InnerText = "Yes";
                _lblDepositAmount.InnerText = eventHostDepositData.Amount.ToString("0.00");
                _lblDepositMethod.InnerText = eventHostPaymentData.PaymentMode == HostPaymentType.Both
                                              ? HostPaymentType.Check + " " + HostPaymentType.CreditCard
                                              : eventHostPaymentData.PaymentMode.ToString();
                _lblDepositDueDate.InnerText = eventHostDepositData.DueDate.HasValue
                                                   ? eventHostDepositData.DueDate.Value.ToShortDateString()
                                                   : string.Empty;
                _lblDepositPayableTo.InnerText = eventHostDepositData.PayableTo;
                _lblDepositAttentionOf.InnerText = eventHostDepositData.MailingAttentionOf;
                _lblDepositOrganizationName.InnerText = eventHostDepositData.MailingOrganizationName;
                _lblDepositAddress.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(CommonCode.AddressMultiLine(eventHostDepositData.EventStreetAddressLine1,
                                                                       eventHostDepositData.EventStreetAddressLine2,
                                                                       eventHostDepositData.EventCity,
                                                                       eventHostDepositData.EventState,
                                                                       eventHostDepositData.EventZip), true);

                _lblDepositApplicablityMode.InnerText = eventHostDepositData.DepositApplicablityMode ==
                                                        DepositType.AppliedToCost
                                                            ? "Applied to Cost of the event"
                                                            : "Returned to corporate offices";
                _lblFullRefundDate.InnerText = eventHostDepositData.DepositFullRefundDueDate.HasValue
                                                   ? eventHostDepositData.DepositFullRefundDueDate.Value.
                                                         ToShortDateString()
                                                   : string.Empty;
            }
            else
                _lblIsDepositRequired.InnerText = "No";
        }
    }
}
