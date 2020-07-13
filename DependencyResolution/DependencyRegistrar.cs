using System;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution.RegistrarSections;

namespace Falcon.App.DependencyResolution
{
    public static class DependencyRegistrar
    {        
        public static void RegisterDependencies()
        {
            RegisterDefaultImplementations();
            //IoC.AutoRegister();
            IoC.Register<IDependencyInjectionHelper, DependencyInjectionHelper>();

            var registrarSections = new IDependencyRegistrarSection[]
            {
                new ApplicationRegistrarSection(),
                new CallCenterRegistrarSection(),
                new FinanceRegistrarSection(),
                new GeoRegistrarSection(),
                new MarketingRegistrarSection(),
                new MedicalRegistrarSection(),
                new OperationsRegistrarSection(),
                new SalesRegistrarSection(),
                new SchedulingRegistrarSection(),
                new UsersRegistrarSection(),                
                new CommunicationRegistrarSection(),
                new LoggingRegistrarSection()
            };

            foreach (var registrarSection in registrarSections)
            {
                registrarSection.RegisterDependencies();
            }

            SetApplicationManager();
        }

        private static void RegisterDefaultImplementations()
        {
            var publicTypes = typeof(DependencyRegistrar).Assembly.GetReferencedAssemblies().Select(Assembly.Load).SelectMany(a => a.GetTypes());
            var interfaces = publicTypes.Where(t => t.IsInterface);
            var defaultImplementations = publicTypes.Where(type => Attribute.IsDefined(type, typeof(DefaultImplementationAttribute)));

            foreach (var type in defaultImplementations)
            {
                var attribute = (DefaultImplementationAttribute)type.GetCustomAttributes(typeof(DefaultImplementationAttribute), false).Single();
                Type typeClosure = type;
                attribute.Interface = attribute.Interface ?? interfaces.SingleOrDefault(i => i.Name == "I" + typeClosure.Name) ?? interfaces.Single();

                IoC.Register(attribute.Interface, type);
            }
        }

        public static void SetApplicationManager()
        {
            ApplicationManager.DependencyInjection = IoC.Resolve<IDependencyInjectionHelper>();
        }
    }
}