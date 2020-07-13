using System;

namespace Falcon.App.Core.ValueTypes
{
    public class AuthcodeInfo
    {
        private readonly string _authCode;
        private readonly long _marketingMaterialId;
        private readonly long _campaignId;
        private readonly long _affiliateId;

        public string AuthCode
        {
            get { return _authCode; }
        }
        public long MarketingMaterialId
        {
            get { return _marketingMaterialId; }
        }
        public long CampaignId
        {
            get { return _campaignId; }
        }
        public long AffiliateId
        {
            get { return _affiliateId; }
        }

        AuthcodeInfo(string authCode, long marketingMaterialId, long campaignId, long affiliateId)
        {
            _authCode = authCode;
            _marketingMaterialId = marketingMaterialId;
            _campaignId = campaignId;
            _affiliateId = affiliateId;
        }

        public static AuthcodeInfo FromDelimitedString(string plainText)
        {
            string authCode = plainText;

            string marketingMaterialId = authCode.Split(new string[] { "//" }, StringSplitOptions.None)[0];
            string campaignId = authCode.Split(new string[] { "//" }, StringSplitOptions.None)[1];
            string affiliateId = authCode.Split(new string[] { "//" }, StringSplitOptions.None)[2];

            campaignId = campaignId.Split(new char[] { '=' })[1];
            marketingMaterialId = marketingMaterialId.Split(new char[] { '=' })[1];
            affiliateId = affiliateId.Split(new char[] { '=' })[1];

            return new AuthcodeInfo(authCode, Convert.ToInt64(marketingMaterialId), Convert.ToInt64(campaignId), Convert.ToInt64(affiliateId));
        }
    }
}