using System;
using System.Configuration;
using System.IO;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.UCPublic
{
    public partial class GiftCertificatePreview : System.Web.UI.UserControl
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        public string PDFURLPath
        {
            get;
            set;
        }

        public string PhysicalPath { get; set; }

        private string Amount
        {
            get { return GiftCertificate.Price.ToString("00.00"); }
        }

        private string FromName
        {
            get { return GiftCertificate.FromName; }
        }

        private string RecipientName
        {
            get { return GiftCertificate.ToName; }
        }

        private string Message
        {
            get { return GiftCertificate.Message; }
        }

        private string GiftCertificateId
        {
            get { return GiftCertificate.Id.ToString(); }
        }

        private string ClaimCode
        {
            get { return GiftCertificate.ClaimCode; }
        }


        private GiftCertificate _giftCertificate;
        private GiftCertificate GiftCertificate
        {
            get
            {
                if (_giftCertificate == null && Session["GiftCertificateId"] != null)
                {
                    long id = 0;
                    long.TryParse(Session["GiftCertificateId"].ToString(), out id);
                    _giftCertificate = IoC.Resolve<IGiftCertificateRepository>().GetById(id);
                }
                else if (Request.QueryString["GiftCertificateId"] != null)
                {
                    long id = 0;
                    long.TryParse(Request.QueryString["GiftCertificateId"], out id);
                    _giftCertificate = IoC.Resolve<IGiftCertificateRepository>().GetById(id);
                }
                return _giftCertificate;
            }
        }

        public bool IsPreviewScreen
        {
            get
            {
                return (!string.IsNullOrEmpty(Request.QueryString["P"]) && Request.QueryString["P"] == "true");
            }
            set
            {
                SendOptionDiv.Visible = !value;
                PrintFinishDiv.Visible = !value;
            }
        }

        public bool IsOnlinePurchase
        {
            get { return Convert.ToBoolean(ViewState["IsOnlinePurchase"]); }
            set { ViewState["IsOnlinePurchase"] = value; }
        }

        public bool IsCallCenterPurchase
        {
            get { return Convert.ToBoolean(ViewState["IsCallCenterPurchase"]); }
            set { ViewState["IsCallCenterPurchase"] = value; }
        }

        public long CustomerId
        {
            get { return Convert.ToInt64(ViewState["CustomerId"]); }
            set { ViewState["CustomerId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsPreviewScreen = IsPreviewScreen;
            }
            if (!IsPreviewScreen)
            {
                SetPageData();
                GeneratePDF();
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "jScripSetPreview", "SetValuesForPreview();", true);
        }

        private void SetPageData()
        {
            FromNameInput.InnerText = FromName;

            AmountInput.InnerText = "$" + Amount;
            MainAmountSpan.InnerText = "$" + Amount;
            ToNameInput.InnerText = RecipientName;

            MessageInput.InnerText = Message;
            ClaimCodeSpan.InnerText = !string.IsNullOrEmpty(ClaimCode) ? ClaimCode : ClaimCodeSpan.InnerText;
        }

        private void IssueNotificationEmail()
        {
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            if (CustomerId <= 0 && Session["CustomerId"] != null)
            {
                CustomerId = Convert.ToInt64(Session["CustomerId"]);
            }
            var customer = customerRepository.GetCustomer(CustomerId);

            var notifier = IoC.Resolve<INotifier>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            string[] emails = null;
            if (CopyToMeCheck.Checked && customer.Email != null && !string.IsNullOrEmpty(customer.Email.ToString()))
            {
                emails = new string[2];
                emails[0] = GiftCertificate.ToEmail;
                emails[1] = customer.Email.ToString();
            }
            else
            {
                emails = new string[1];
                emails[0] = GiftCertificate.ToEmail;
            }

            var acknowledgmentmail = emailNotificationModelsFactory.GetGiftCertificateNotificationModel(GiftCertificate.ClaimCode, GiftCertificate.FromName, GiftCertificate.ToName, GiftCertificate.Message, GiftCertificate.Price);

            //Sending acknowledgmentmail
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.GiftCertificateAcknowledgmentEmail, EmailTemplateAlias.GiftCertificateAcknowledgmentEmail, acknowledgmentmail, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.GiftCertificateClaimCodeEmail, EmailTemplateAlias.GiftCertificateClaimCodeEmail, acknowledgmentmail, emails, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
        }

        private void GeneratePDF()
        {
            if (Request.QueryString["Pdf"] != null) return;
            string pageUrl = Request.Url.OriginalString.Replace(Request.Url.PathAndQuery, "/App/Common/" + "GiftCertificatePDF.aspx?GcId=" + GiftCertificateId);

            var generatedClaimCode = ClaimCodeSpan.InnerText;
            var invalid = new string(Path.GetInvalidFileNameChars());
            foreach (char c in invalid)
            {
                generatedClaimCode = generatedClaimCode.Replace(c.ToString(), "");
            }
            string fileName = "GiftCertificate-" + (!string.IsNullOrEmpty(ClaimCode) ? ClaimCode : generatedClaimCode) + "-" + GiftCertificateId;

            var mediaLocation = IoC.Resolve<IMediaRepository>().GetGiftCertificateMediaFileLocation();

            var pdfConverterPath = Server.MapPath(@"~\bin");

            fileName = IoC.Resolve<IPdfGenerator>().Generate(pageUrl, mediaLocation.PhysicalPath, pdfConverterPath, fileName);


            PhysicalPath = mediaLocation.PhysicalPath + "//" + fileName;
            PDFURLPath = mediaLocation.Url + "//" + fileName;

        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            if (SendGCNotification.Checked)
            {
                IssueNotificationEmail();
            }

            Session["GiftCertificateId"] = null;

            if (Request.QueryString[RefundRequest.ProcessRequest] != null)
            {
                Session["CustomerId"] = null;
                Response.RedirectUser("/Finance/RefundRequest");
            }

            if (IsOnlinePurchase)
                Response.RedirectUser(ConfigurationManager.AppSettings["HomePage"]);
            else if (IsCallCenterPurchase)
                Response.RedirectUser("/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + GuId);
        }

    }
}