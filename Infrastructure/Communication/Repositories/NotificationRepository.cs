using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation(Interface = typeof(INotificationRepository))]
    public class NotificationRepository : INotificationRepository
    {
        private readonly IPersistenceLayer _persistenceLayer;
        private readonly IMapper<Notification, NotificationEntity> _notificationMapper;
        private readonly IMapper<NotificationEmail, NotificationEmailEntity> _notificationEmailMapper;
        private readonly IMapper<NotificationPhone, NotificationPhoneEntity> _notificationPhoneMapper;
        private readonly ICustomerRepository _customerRepository;

        public NotificationRepository(IPersistenceLayer persistenceLayer,
            IMapper<Notification, NotificationEntity> notificationMapper,
            IMapper<NotificationEmail, NotificationEmailEntity> notificationEmailMapper, ICustomerRepository customerRepository, IMapper<NotificationPhone, NotificationPhoneEntity> notificationPhoneMapper)
        {
            _persistenceLayer = persistenceLayer;
            _notificationMapper = notificationMapper;
            _notificationEmailMapper = notificationEmailMapper;
            _customerRepository = customerRepository;
            _notificationPhoneMapper = notificationPhoneMapper;

        }

        public IEnumerable<Notification> GetNotificationsAfter(DateTime inclusiveStartTime)
        {
            using (var myAdapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return _notificationMapper.MapMultiple(NotificationEntities(linqMetaData).Where(n => n.DateCreated >= inclusiveStartTime)).ToList();
            }
        }

        public IEnumerable<Notification> GetNotificationsToService(long[] mediumIds)
        {
            using (var myAdapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities =
                    NotificationEntities(linqMetaData)
                        .Where(n => n.ServiceStatus == (int)NotificationServiceStatus.Unserviced && mediumIds.Contains(n.NotificationMediumId))
                        .ToArray();
                return _notificationMapper.MapMultiple(entities);
            }
        }

        public Notification Save(Notification domainObject)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                if (domainObject.UserId > 0)
                {
                    try
                    {
                        var customer = _customerRepository.GetCustomerByUserId(domainObject.UserId);
                        if (customer != null && ((customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)) || !customer.EnableEmail))
                        //(customer.DoNotContactReasonId.HasValue && customer.DoNotContactReasonId.Value > 0))
                        {
                            return null;
                        }
                    }
                    catch (ObjectNotFoundInPersistenceException<Customer>)
                    {
                        //Do Nothing
                    }
                }

                NotificationEntity notificationEntity = _notificationMapper.Map(domainObject);
                if (!adapter.SaveEntity(notificationEntity, true, false))
                {
                    throw new PersistenceFailureException("Could not save Notification.");
                }

                if (domainObject as NotificationEmail != null)
                {
                    NotificationEmailEntity notificationEmailEntity = _notificationEmailMapper.Map(domainObject as NotificationEmail);
                    notificationEmailEntity.IsNew = domainObject.Id == 0;
                    notificationEmailEntity.NotificationEmailId = notificationEntity.NotificationId;
                    if (!adapter.SaveEntity(notificationEmailEntity, true))
                    {
                        throw new PersistenceFailureException("Could not save NotificationEmail.");
                    }

                    notificationEntity.NotificationEmail = notificationEmailEntity;
                }

                if (domainObject as NotificationPhone == null) return _notificationMapper.Map(notificationEntity);

                var notificationPhone = _notificationPhoneMapper.Map(domainObject as NotificationPhone);
                notificationPhone.IsNew = domainObject.Id == 0;
                notificationPhone.NotificationPhoneId = notificationEntity.NotificationId;
                if (!adapter.SaveEntity(notificationPhone, true))
                {
                    throw new PersistenceFailureException("Could not save NotificationEmail.");
                }

                notificationEntity.NotificationPhone = notificationPhone;

                return _notificationMapper.Map(notificationEntity);
            }
        }

        public void Delete(Notification domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Notification> domainObjects)
        {
            throw new NotImplementedException();
        }

        public Notification GetById(long id)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                NotificationEntity objectToMapFrom = NotificationEntities(linqMetaData)
                    .Single(n => n.NotificationId == id);
                return _notificationMapper.Map(objectToMapFrom);
            }
        }

        public NotificationEmail GetEmailNotificationById(long id)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                NotificationEntity objectToMapFrom = NotificationEntities(linqMetaData)
                    .Single(n => n.NotificationId == id);
                return _notificationEmailMapper.Map(objectToMapFrom.NotificationEmail);
            }
        }


        public IEnumerable<Notification> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var objectToMapFrom = NotificationEntities(linqMetaData).Where(n => ids.Contains(n.NotificationId));
                return _notificationMapper.MapMultiple(objectToMapFrom);
            }
        }

        private static IQueryable<NotificationEntity> NotificationEntities(LinqMetaData linqMetaData)
        {
            return linqMetaData.Notification
                .WithPath(p => p.Prefetch(n => n.NotificationEmail).Prefetch(n => n.NotificationPhone));
        }

        public void SaveProspectCustomerNotification(long prospectCustomerId, long notificationId)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ProspectCustomerNotificationEntity(prospectCustomerId, notificationId);
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<Notification> GetFaxNotificationByNotificationTypeId(long mediumId, long notificationTypeId)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities =
                    NotificationEntities(linqMetaData)
                        .Where(n => n.NotificationTypeId == notificationTypeId && n.ServiceStatus == (int)NotificationServiceStatus.Unserviced && n.NotificationMediumId == mediumId)
                        .ToArray();
                return _notificationMapper.MapMultiple(entities);
            }
        }

        public Notification GetLatestNotificationByPhone(string phoneNumber)
        {
            using (var adapter = _persistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var phoneNotificationId = (from np in linqMetaData.NotificationPhone
                                           where np.PhoneCell == phoneNumber
                                           select np.NotificationPhoneId);


                var notification = (from n in linqMetaData.Notification
                                    where phoneNotificationId.Contains(n.NotificationId)
                                    orderby n.DateCreated descending
                                    select n).FirstOrDefault();

                if (notification == null) return null;

                return GetById(notification.NotificationId);
            }
        }
    }
}