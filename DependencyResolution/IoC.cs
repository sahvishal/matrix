using System;
using System.Diagnostics;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace Falcon.App.DependencyResolution
{
    public static class IoC
    {
        private static readonly UnityContainer _unityContainer = new UnityContainer();

        public static AbstractType Resolve<AbstractType>()
        {
            return _unityContainer.Resolve<AbstractType>();
        }

        [DebuggerNonUserCode]
        public static TBase Resolve<TBase>(string name)
        {
            return _unityContainer.Resolve<TBase>(name);            
        }

        public static object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

       public static void Register(Type @base, Type concreteType)
        {
            if (!@base.IsAssignableFrom(concreteType) && !@base.IsGenericType)
            {
                throw new InvalidDependencyRegistrationException(@base, @concreteType);
            }
            _unityContainer.RegisterType(@base, concreteType);            
        }


        public static void Register<AbstractType, ConcreteType>() where ConcreteType : AbstractType
        {
            _unityContainer.RegisterType<AbstractType, ConcreteType>();
        }

        public static void Register<TBase>(string name, Type type)
        {
            if (!typeof(TBase).IsAssignableFrom(type))
            {
                throw new InvalidDependencyRegistrationException(typeof(TBase), type);
            }
            _unityContainer.RegisterType(typeof(TBase), type, name);
        }


        internal static void Register<AbstarctType, ConcreteType>(params InjectionMember[] injectionMembers) where ConcreteType : AbstarctType
        {
            _unityContainer.RegisterType<AbstarctType, ConcreteType>(injectionMembers);
        }

        internal static void  AutoRegister()
        {
            _unityContainer.ConfigureAutoRegistration()                
                .Include(type => type.ImplementsOpenGeneric(typeof(IMapper<,>)), Then.Register().AsFirstInterfaceOfType().WithPartName("Mapper"))
                .ApplyAutoRegistration();
        }

        public static void RegisterInstance<AbstractType>(AbstractType instance)
        {
            _unityContainer.RegisterInstance(instance);
        }
    }
}