using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;

namespace Falcon.App.UI.App.Common
{
    public partial class GiftCertificatePDF : System.Web.UI.Page
    {
        private GiftCertificate GiftCertificate
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["GcId"]))
                {
                    long giftCertificateId;
                    if (Int64.TryParse(Request.QueryString["GcId"], out giftCertificateId))
                    {
                        IGiftCertificateRepository giftCertificateRepository = new GiftCertificateRepository();
                        return giftCertificateRepository.GetById(giftCertificateId);
                    }
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var giftCertificate = GiftCertificate;
            if (giftCertificate != null)
            {
                FromNameInput.InnerText = FromNameSpan.InnerText = giftCertificate.FromName;
                AmountInput.InnerText = "$" + giftCertificate.Price.ToString("0.00");
                ToNameInput.InnerText = giftCertificate.ToName;
                MessageInput.InnerText = giftCertificate.Message;
                ClaimCodeSpan.InnerText = giftCertificate.ClaimCode;
            }
        }
    }
}
