using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class TempcartService : ITempcartService
    {
        private readonly ITempCartRepository _tempCartRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public TempcartService(ITempCartRepository tempCartRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _tempCartRepository = tempCartRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public OnlineRequestValidationModel ValidateOnlineRequest(string guid)
        {

            if (string.IsNullOrEmpty(guid))
                return new OnlineRequestValidationModel { RequestStatus = OnlineRequestStatus.Valid, CaptureOnlineHaf = true };

            var tempCart = _tempCartRepository.Get(guid);
            var onlineRequestValidationModel = new OnlineRequestValidationModel { TempCart = tempCart };
            if (tempCart != null)
            {

                if (tempCart.DateCreated.AddDays(1) < DateTime.Now)
                {
                    onlineRequestValidationModel.RequestStatus = OnlineRequestStatus.InvalidOperation;
                }
                else
                {
                    onlineRequestValidationModel.RequestStatus = OnlineRequestStatus.Valid;
                }

            }
            else
            {
                tempCart = _tempCartRepository.Get(guid, true);
                onlineRequestValidationModel.TempCart = tempCart;

                onlineRequestValidationModel.RequestStatus = tempCart != null
                    ? OnlineRequestStatus.Completed
                    : OnlineRequestStatus.InValid;

            }

            CorporateAccount account = null;

            if (tempCart != null && tempCart.EventId.HasValue && (onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.Completed || onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.Valid))
            {
                account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);
            }

            onlineRequestValidationModel.CaptureOnlineHaf = (account == null || account.CaptureHafOnline);
            onlineRequestValidationModel.IsCorporateEvent = (account != null);

            return onlineRequestValidationModel;
        }

        public void SaveTempCart(TempCart tempCart)
        {
            if (tempCart.Id > 0)
                tempCart.DateModified = DateTime.Now;
            else
            {
                tempCart.DateCreated = DateTime.Now;
            }
            _tempCartRepository.Save(tempCart);
        }

        public void UpdateTempCartExitPage(string exitPage, TempCart tempCart)
        {
            tempCart.ExitPage = exitPage;
            _tempCartRepository.Save(tempCart);
        }
    }
}
