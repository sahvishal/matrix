using System;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class GiftCertificateDetails : UserControl
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        public delegate void NavigateOnSubmitClick();
        public event NavigateOnSubmitClick navigateOnSubmitClick;
        public event NavigateOnSubmitClick navigateOnChangeAmountClick;

        private decimal? Amount
        {
            get
            {
                decimal? amount = null;
                if (!string.IsNullOrEmpty(Request.QueryString["Amount"]))
                {
                    decimal a;
                    if (Decimal.TryParse(Request.QueryString["Amount"], out a))
                    {
                        amount = a;
                    }
                }
                return amount;
            }
        }

        public long GiftCertificateId
        {
            get
            {
                long giftCertificateId = 0;
                if (Session["GiftCertificateId"] != null)
                    long.TryParse(Session["GiftCertificateId"].ToString(), out giftCertificateId);
                return giftCertificateId;
            }
            set { Session["GiftCertificateId"] = value; }
        }

        private GiftCertificate _giftCertificate;
        private GiftCertificate GiftCertificate
        {
            get
            {
                if (_giftCertificate == null && GiftCertificateId > 0)
                {
                    _giftCertificate = IoC.Resolve<IGiftCertificateRepository>().GetById(GiftCertificateId);
                }
                return _giftCertificate;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[RefundRequest.ProcessRequestId] != null)
            {
                ChangeAmountAnchorContainer.Style[HtmlTextWriterStyle.Display] = "none";
            }

            if (!Page.IsPostBack)
            {
                AmountLabel.Text += Amount.HasValue ? Amount.Value.ToString("00.00") : "00.00";
                TotalAmountLiteral.Text = AmountLabel.Text;
                BindGiftCertificateTypeCombo();

                if (GiftCertificate != null)
                {
                    RecipientNameText.Text = GiftCertificate.ToName;
                    RecipientEmailText.Text = GiftCertificate.ToEmail;
                    FromNameText.Text = GiftCertificate.FromName;
                    GiftCertificateTypeCombo.SelectedValue = GiftCertificate.GiftCertificateTypeId.ToString();
                    MessageTextBox.Text = GiftCertificate.Message;
                }

            }
        }

        protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    SaveDataToSession();
                    SaveGiftCertificateOrderforRequest();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "js_alerterror",
                                                                     "alert('OOPS! Some error occured while saving details. Message: " + ex.Message + "');",
                                                                     true);
                GiftCertificateId = 0;
                return;
            }

            if (Session[RefundRequest.ProcessRequestId] != null)
            {
                Session[RefundRequest.ProcessRequestId] = null;
                Response.RedirectUser("/App/CallCenter/CallCenterRep/GiftCertificate/EmailSample.aspx?Call=No&" +
                                  RefundRequest.ProcessRequest + "=true");

            }
            navigateOnSubmitClick();
        }

        private void BindGiftCertificateTypeCombo()
        {
            IGiftCertificateTypeRepository giftCertificateTypeRepository = new GiftCertificateTypeRepository();
            var giftCertificateTypes = giftCertificateTypeRepository.GetAllGiftCertificateTypes();
            GiftCertificateTypeCombo.DataSource = giftCertificateTypes;
            GiftCertificateTypeCombo.DataTextField = "Name";
            GiftCertificateTypeCombo.DataValueField = "Id";
            GiftCertificateTypeCombo.AppendDataBoundItems = true;
            GiftCertificateTypeCombo.DataBind();

            var selectedGc = giftCertificateTypes.Where(gct => gct.Name.Trim().ToLower().Equals("other")).FirstOrDefault();
            var item = GiftCertificateTypeCombo.Items.FindByValue(selectedGc.Id.ToString());
            if (item != null) item.Selected = true;
        }

        protected void ChangeAmountAnchor_ServerClick(object sender, EventArgs e)
        {
            if (Session[RefundRequest.ProcessRequestId] != null)
            {
                Response.RedirectUser("/Finance/RefundRequest/Edit?id=" + Session[RefundRequest.ProcessRequestId]);
            }

            navigateOnChangeAmountClick();
        }

        private void SaveDataToSession()
        {
            var giftCertificateRepository = IoC.Resolve<IGiftCertificateRepository>();

            if (GiftCertificate == null)
            {
                _giftCertificate = new GiftCertificate
                                       {
                                           Price = Amount.Value,
                                           ToName = RecipientNameText.Text,
                                           FromName = FromNameText.Text,
                                           Message = MessageTextBox.Text,
                                           ToEmail = RecipientEmailText.Text,
                                           GiftCertificateTypeId =
                                               !string.IsNullOrEmpty(GiftCertificateTypeCombo.SelectedValue)
                                                   ? Convert.ToInt64(GiftCertificateTypeCombo.SelectedValue)
                                                   : 0
                                       };

                var claimCodeGenerator = new ClaimCodeGenerator();
                var claimCode = claimCodeGenerator.GenerateClaimCode();

                while (!giftCertificateRepository.IsClaimCodeValidForCertificate(claimCode, 0))
                {
                    claimCode = claimCodeGenerator.GenerateClaimCode();
                }

                _giftCertificate.ClaimCode = claimCode;
            }
            else
            {
                _giftCertificate.Price = Amount.Value;
                _giftCertificate.ToName = RecipientNameText.Text;
                _giftCertificate.FromName = FromNameText.Text;
                _giftCertificate.Message = MessageTextBox.Text;
                _giftCertificate.ToEmail = RecipientEmailText.Text;
                _giftCertificate.GiftCertificateTypeId =
                    !string.IsNullOrEmpty(GiftCertificateTypeCombo.SelectedValue)
                        ? Convert.ToInt64(GiftCertificateTypeCombo.SelectedValue)
                        : 0;
            }
            var userSession = IoC.Resolve<ISessionContext>().UserSession;
            var creatorOrganizationRoleUser =
                IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(userSession.CurrentOrganizationRole,
                                                                userSession.UserId);
            _giftCertificate.DataRecorderMetaData = new DataRecorderMetaData
            {
                DataRecorderCreator = creatorOrganizationRoleUser,
                DateCreated = DateTime.Now
            };

            _giftCertificate = giftCertificateRepository.Save(_giftCertificate);
            GiftCertificateId = _giftCertificate.Id;
        }

        private void SaveGiftCertificateOrderforRequest()
        {
            if (Session[RefundRequest.ProcessRequestId] == null) return;
            var requestId = Convert.ToInt64(Session[RefundRequest.ProcessRequestId]);

            if (requestId < 1) return;

            var refundRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequest = refundRepository.Get(requestId);

            var forOrganizationRoleUser = new OrganizationRoleUser(refundRequest.CustomerId);
            var userSession = IoC.Resolve<ISessionContext>().UserSession;

            var giftCertificateRepository = IoC.Resolve<IGiftCertificateRepository>();

            try
            {
                giftCertificateRepository.ActivateGiftCertificate(GiftCertificate.Id);
            }
            catch (Exception)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "js_alerterror",
                                                             "alert('OOPS! Some error occured while saving details.');",
                                                             true);
                return;
            }

            var orderRepository = IoC.Resolve<IOrderRepository>();
            var order = orderRepository.GetOrder(refundRequest.OrderId);
            IOrderController orderController = new OrderController();
            orderController.AddItem(GiftCertificate, 1, forOrganizationRoleUser.Id,
                                    userSession.CurrentOrganizationRole.OrganizationRoleUserId, OrderStatusState.FinalSuccess);

            if (refundRequest.RefundRequestType == RefundRequestType.CustomerCancellation || refundRequest.RefundRequestType == RefundRequestType.EventCancellation || refundRequest.RefundRequestType == RefundRequestType.ForcedCancellation)
                orderController.NegateAppointmentOrderagainstGiftCertificate(order, refundRequest.CustomerId, userSession.CurrentOrganizationRole.OrganizationRoleUserId);
            else
                orderController.AdjustOrderagainstGiftCertificate(order, refundRequest.CustomerId, userSession.CurrentOrganizationRole.OrganizationRoleUserId);

            if (order == null || order.Id < 1)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "js_alerterror", "alert('OOPS! Some error occured while saving details.');", true);
                return;
            }

            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomer(refundRequest.CustomerId);

            //var notifier = IoC.Resolve<INotifier>();
            //var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

            //var acknowledgmentmail = emailNotificationModelsFactory.GetGiftCertificateNotificationModel(GiftCertificate.ClaimCode, GiftCertificate.FromName, GiftCertificate.ToName, GiftCertificate.Message, GiftCertificate.Price);
            //notifier.NotifySubscribersViaEmail(NotificationTypeAlias.GiftCertificateAcknowledgmentEmail, EmailTemplateAlias.GiftCertificateAcknowledgmentEmail, acknowledgmentmail, customer.Id, userSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

            refundRequest.RefundRequestResult.ProcessedOn = DateTime.Now;
            refundRequest.RequestStatus = (long)RequestStatus.Resolved;
            refundRequest.RefundRequestResult.ProcessedByOrgRoleUserId =
                userSession.CurrentOrganizationRole.OrganizationRoleUserId;
            refundRequest.RefundRequestResult.RequestResultType = RequestResultType.IssueGiftCertificate;

            ((IRepository<RefundRequest>)refundRepository).Save(refundRequest);
            refundRepository.SaveRequestandGiftCertificateMapping(refundRequest.Id, GiftCertificateId);
            Session["CustomerId"] = customer.CustomerId;

        }

    }
}