using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UCInvoice : UserControl
    {
        public long MedicalVendorInvoiceId;
        public long MedicalVendorMedicalVendorUserId;
        public bool CanSeeEarnings;
        private readonly IMedicalVendorInvoiceRepository _invoiceRepository = new MedicalVendorInvoiceRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PhysicianInvoice medicalVendorInvoice = _invoiceRepository.
                    GetOldestUnapprovedInvoiceForMedicalVendorUser(MedicalVendorMedicalVendorUserId);
                if (medicalVendorInvoice != null)
                {
                    SetMedicalVendorInoviceDisplayControls(medicalVendorInvoice);
                }
                else
                {
                    throw new Exception("No invoices exist.");
                }
            }
        }

        protected void SetMedicalVendorInoviceDisplayControls(PhysicianInvoice medicalVendorInvoice)
        {
            invoiceNumberLiteral.Text = HttpUtility.UrlEncode(medicalVendorInvoice.Id.ToString());
            payPeriodLiteral.Text = medicalVendorInvoice.PayPeriodString;
            physicianNameLiteral.Text = HttpUtility.UrlEncode(medicalVendorInvoice.PhysicianName);
            medicalVendorNameLiteral.Text = medicalVendorInvoice.MedicalVendorName;

            NumberOfEvaluationsLiteral.Text = medicalVendorInvoice.MedicalVendorInvoiceItems.Count.ToString();
            TotalAmountEarnedLiteral.Text = string.Format("{0:c}", medicalVendorInvoice.MedicalVendorInvoiceItems.
                Sum(i => i.OrganizationRoleUserAmountEarned));

            invoiceItemRepeater.DataSource = medicalVendorInvoice.MedicalVendorInvoiceItems.OrderBy(i => i.ReviewDate);
            invoiceItemRepeater.DataBind();
        }
    }
}