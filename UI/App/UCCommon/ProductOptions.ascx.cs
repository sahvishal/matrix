using System;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class ProductOptions : UserControl
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

        public bool IsProductSelected
        {
            set { ProductCheckbox.Checked = value; }
            get { return ProductCheckbox.Checked; }
        }
        public bool IsProductCheckboxEnabled { set { ProductCheckbox.Enabled = value; } }
        public long ProductId
        {
            get { return Convert.ToInt64(hfProfuctID.Value); }
        }

        public decimal ProductPrice
        {
            get { return Convert.ToDecimal(hfProductPrice.Value); }
        }

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
            }
        }

        public long EventId { get; set; }

        public long UpsellProductId
        {
            get { return Convert.ToInt64(hfUpsellProductId.Value); }
            set { hfUpsellProductId.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProduct();

                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                {
                    IElectronicProductRepository electronicProductRepository = new ElectronicProductRepository();
                    var product = electronicProductRepository.GetById(RegistrationFlow.ProductId);
                    if (ShippingOptionId.HasValue)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_SetProduct",
                                                                "SelectProduct('" + RegistrationFlow.ProductId + "','" + product.Price + "',false);", true);
                    else
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_SetProduct",
                                                                "SelectProduct('" + RegistrationFlow.ProductId + "','" + product.Price + "',true);", true);
                }

            }
        }

        public bool IsUpsellImageAllowed
        {
            get
            {
                if (EventId <= 0) return true;

                var corporateAccountRepository = IoC.Resolve<CorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(EventId);

                return account == null || account.EnableImageUpsell;    
            }
        }

        private void BindProduct()
        {
            try
            {
                IElectronicProductRepository electronicProductRepository = new ElectronicProductRepository();
                var electronicProducts = electronicProductRepository.GetAllProductsForEvent(EventId);

                if (electronicProducts != null && electronicProducts.Count > 0)
                {
                    UpsellProductId = electronicProducts[0].Id;
                    grdvProduct.DataSource = electronicProducts.OrderBy(ep => ep.Price);
                    grdvProduct.DataBind();
                }
                else
                {
                    ProductOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }
            catch (EmptyCollectionException)
            {
                ProductOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

        }
    }
}