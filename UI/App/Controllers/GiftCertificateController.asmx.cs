using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.Controllers
{
    /// <summary>
    /// Summary description for GiftCertificateController
    /// </summary>
    [WebService(Namespace = "http://GiftCertificateController.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GiftCertificateController : WebService, IGiftCertificateController
    {

        [WebMethod(EnableSession = true)]
        public List<GiftCertificateOfferingsViewData> GetCompleteGiftCertificateOfferingViewData()
        {
            IPackageRepository packageRepository = new PackageRepository();
            var packages = packageRepository.GetAll().OrderByDescending(p => p.Price);
            var viewData = packages.CreateGiftCertificateOfferingsViewData();
            return viewData;
            //return GetNewGiftCertificateOfferingViewData();
        }

        [WebMethod(EnableSession = true)]
        public List<GiftCertificateOfferingsViewData> GetNewGiftCertificateOfferingViewData()
        {
            IPackageRepository packageRepository = new PackageRepository();
            var viewData =
                packageRepository.GetAll().Where(
                    package => (package.Id == (long)NewPackages.BronzePreventionPAK)
                    || (package.Id == (long)NewPackages.GoldPreventionPAK)
                    || (package.Id == (long)NewPackages.PlatinumPreventionPAK)
                    || (package.Id == (long)NewPackages.SilverPreventionPAK)).
                    CreateGiftCertificateOfferingsViewData();
            return viewData;
        }

        [WebMethod(EnableSession = true)]
        public object GetGiftCertificateByClaimCode(string claimCode)
        {
            IGiftCertificateService giftCertificateService = new GiftCertificateService(new GiftCertificateRepository());

            GiftCertificate giftCertificate = null;
            var message = string.Empty;
            var isSucess = false;
            try
            {
                giftCertificate = giftCertificateService.GetGiftCertificatebyClaimCode(claimCode);
                isSucess = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return new { Data = giftCertificate, Message = message, IsSuccess = isSucess };
        }

        [WebMethod(EnableSession = true)]
        public GiftCertificate GetGiftCertificateById(long giftCertificateId)
        {
            IGiftCertificateRepository giftCertificateRepository = new GiftCertificateRepository();
            var giftCertificate = giftCertificateRepository.GetById(giftCertificateId);
            if (giftCertificate != null)
            {
                //TODO Need to check the table tblGiftCertificatePayment for pulling the exhausted amount.
                //var masterDal = new MasterDAL();
                //giftCertificate.Amount = masterDal.GetExhaustedGiftCertificateAmount(giftCertificate.Id);
                giftCertificate.Amount = giftCertificateRepository.GetAmountUsedonGiftCertificate(giftCertificate.Id);
                if (giftCertificate.BalanceAmount > 0
                    && ((giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate >= DateTime.Today) || !giftCertificate.ExpirationDate.HasValue))
                    return giftCertificate;

                if (giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate < DateTime.Today)
                    throw new ObjectDeactivatedException<GiftCertificate>();

                throw new InvalidOperationException(
                    "There is no amount left in the given gift certificate, please use another mode to pay.");
            }
            throw new InvalidOperationException("The given gift certificate is not valid.");
        }

        [WebMethod(EnableSession = true)]
        public GiftCertificate GetGiftCertificate(long giftCertificateId)
        {
            IGiftCertificateRepository giftCertificateRepository = new GiftCertificateRepository();
            var giftCertificate = giftCertificateRepository.GetById(giftCertificateId);
            if (giftCertificate != null)
            {
                IUniqueItemRepository<GiftCertificatePayment> uniqueItemRepository =
                    new GiftCertificatePaymentRepository();

                GiftCertificatePayment giftCertificatePayment = null;
                try
                {
                    giftCertificatePayment = uniqueItemRepository.GetById(giftCertificateId);
                }
                catch (ObjectNotFoundInPersistenceException<GiftCertificatePayment>)
                { }

                giftCertificate.Amount = giftCertificatePayment == null ? 0 : giftCertificatePayment.Amount;

                if (giftCertificate.BalanceAmount > 0
                    && ((giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate >= DateTime.Today) || !giftCertificate.ExpirationDate.HasValue))
                    return giftCertificate;

                if (giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate < DateTime.Today)
                    throw new ObjectDeactivatedException<GiftCertificate>();

                throw new InvalidOperationException(
                    "There is no amount left in the given gift certificate, please use another mode to pay.");
            }
            throw new InvalidOperationException("The given gift certificate is not valid.");
        }

    }
}
