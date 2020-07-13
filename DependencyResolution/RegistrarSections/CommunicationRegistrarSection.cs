using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Impl;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Infrastructure.Communication;
using Falcon.App.Infrastructure.Communication.Impl;
using Falcon.App.Infrastructure.Communication.Mappers;
using Falcon.App.Infrastructure.Communication.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class CommunicationRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            RegisterRepositories();
            RegisterMappers();

            IoC.Register<INotificationPollingAgent, NotificationPollingAgent>();
            IoC.Register<IEmailTemplateFormatter, EmailTemplateFormatter>();
            IoC.RegisterInstance(IoC.Resolve<SmtpCredentials>() as ISmtpCredentials);
            IoC.RegisterInstance(IoC.Resolve<NotificationEmailSender>() as INotificationEmailSender);

            //Factory
            IoC.RegisterInstance(IoC.Resolve<EmailNotificationModelsFactory>() as IEmailNotificationModelsFactory);
            IoC.RegisterInstance(IoC.Resolve<PhoneNotificationModelsFactory>() as IPhoneNotificationModelsFactory);
            
        }

        private void RegisterMappers()
        {
            //TODO: Bidhan have to look into this            
            IoC.Register<IMapper<EmailTemplate, EmailTemplateEntity>, EmailTemplateMapper>();
            IoC.Register<IMapper<Notification, NotificationEntity>, NotificationMapper>();
            IoC.Register<IMapper<NotificationType, NotificationTypeEntity>, NotificationTypeMapper>();
            IoC.Register<IMapper<NotificationMedium, NotificationMediumEntity>, NotificationMediumMapper>();
            IoC.Register<IMapper<NotificationSubscriber, NotificationSubscribersEntity>, NotificationSubscriberMapper>();
            IoC.Register<IMapper<NotificationEmail, NotificationEmailEntity>, NotificationEmailMapper>();
            IoC.Register<IMapper<NotificationPhone, NotificationPhoneEntity>, NotificationPhoneMapper>();
            IoC.Register<IPopulator<NotificationEntity, Notification>, CommonNotificationPopulator>();            
        }

        private void RegisterRepositories()
        {
            // TODO: why are these not getting caught?
            IoC.Register<IEmailTemplateRepository, EmailTemplateRepository>();
            IoC.Register<INotificationRepository, NotificationRepository>();
            IoC.Register<INotificationTypeRepository, NotificationTypeRepository>();
            IoC.Register<INotificationMediumRepository, NotificationMediumRepository>();
            IoC.Register<INotificationSubscriberRepository, NotificationSubscriberRepository>();
        }
    }
}