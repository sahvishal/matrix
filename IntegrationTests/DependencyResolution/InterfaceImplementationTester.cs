using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.DependencyResolution
{
    [TestFixture]
    public class InterfaceImplementationTester
    {
        [Test]
        [Ignore]
        public void EnsureInterfacesWithSimilarlyNamedTypesAreRegistered()
        {
            DependencyRegistrar.RegisterDependencies();
            MethodInfo resolveMethod = typeof(IoC).GetMethod("Resolve");

            AssemblyName[] assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            IEnumerable<Assembly> assemblies = assemblyNames.Where(an => an.FullName.StartsWith("Falcon")).Select(Assembly.Load);
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetTypes());

            var invalidMappings = new List<string>();

            foreach (Type type in types.Where(t => t.IsClass))
            {
                foreach (Type implementedInterface in type.GetInterfaces())
                {
                    if (implementedInterface.Name == "I" + type.Name)
                    {
                        try
                        {
                            MethodInfo genericMethod = resolveMethod.MakeGenericMethod(new[] { implementedInterface });
                            genericMethod.Invoke(null, null);
                        }
                        catch
                        {
                            invalidMappings.Add(string.Format("{0} does not implement {1}", type.FullName, implementedInterface.FullName ?? implementedInterface.Name));
                        }
                    }
                }
            }

            Assert.IsEmpty(invalidMappings, string.Join(Environment.NewLine, invalidMappings.ToArray()));
        }

        [Test]

        public void EnsureUserRepositoryDependanciesRegistered()
        {
            DependencyRegistrar.RegisterDependencies();


            var userRepository = IoC.Resolve<IOrganizationService>();

        }

        [Test]
        [Ignore]
        public void CheckPaymentGatewayisConfiguredornot()
        {
            DependencyRegistrar.RegisterDependencies();


            IPaymentProcessor paymentProcessor = IoC.Resolve<IPaymentProcessor>();

            paymentProcessor.ChargeCreditCard(new CreditCardProcessorProcessingInfo
            {
                CreditCardNo = "4007000000027",
                SecurityCode = "211",
                ExpiryMonth = 12,
                ExpiryYear = 2012,
                CardType = "Visa",
                Price = "12",
                FirstName = "Bidhan",
                LastName = "Bidhan",
                BillingAddress = "My Address",
                BillingCity = "Austin",
                BillingState = "Texas",
                BillingPostalCode = "78705",
                BillingCountry = "US",
                Email = "mail.email.com",
                IpAddress = "198.172.10.10",
                Currency = "USD",
                OrderId = "123456789"
            });

        }

        [Test]
        public void CheckDiIsWorkingOrNot()
        {
           
            DependencyRegistrar.RegisterDependencies();
            var notificationPollingAgent = IoC.Resolve<INotificationPollingAgent>();
            notificationPollingAgent.PollForNotifications();
        }

        [Test]
        public void FaxNotification()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            var notificationPollingAgent = IoC.Resolve<IPhysicianPartnerSendFaxPollingAgent>();
            notificationPollingAgent.PollForNotifications();
        }
    }
}