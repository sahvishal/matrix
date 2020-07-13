using System;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class CustomCampaignContent : UserControl
    {
        private bool _enabled = true;
        public bool IsEnabled
        {
            get { return _enabled;  }
            set { _enabled = value; }
        }

        public long CampaignId { get; set; }

        public string Tag { get; set; }        

        public string Selector { get; set; }
        public string DefaultContent { get; set; }
        
        public string TemplateData { get; set; }

        private string _content;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _content = DefaultContent;
            GetContent();
        }

        public void GetContent()
        {
            HttpCookie advertiserCookie = Context.Request.Cookies["advertiserCookie"];

            try
            {
                if (advertiserCookie != null)
                {
                    string authCode = HttpUtility.UrlDecode(advertiserCookie.Value).Replace(' ', '+');
                    var encryptionHelper = new EncryptionHelper();
                    string decryptedAuthCode = encryptionHelper.Decrypt(authCode);

                    AuthcodeInfo authcodeInfo = AuthcodeInfo.FromDelimitedString(decryptedAuthCode);

                    CampaignId = authcodeInfo.CampaignId;
                }
            }
            catch
            {
                // If an exception occurs, just use the default CampaignId.
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!_enabled)
            {
                return;
            }

            try
            {
                var repository = new CustomCampaignContentRepository();
                MarketingMaterial marketingMaterial = repository.GetCustomContent(CampaignId, Tag);
                _content = marketingMaterial.HTMLText;
            }   
            catch
            {
                // Just continue using the default content.
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(_content);
        }        
        
    }
}