using System;
using Falcon.App.Core.Application;

namespace Falcon.App.DependencyResolution
{
    public class DependencyInjectionHelper : IDependencyInjectionHelper
    {
        public T Resolve<T>()
        {
            return IoC.Resolve<T>();
        }

        public object Resolve(Type obj)
        {
            return IoC.Resolve(obj);
        }

        public T Resolve<T>(string name)
        {
            return IoC.Resolve<T>(name);
        }

        public void Register<TAbstract, TConcrete>() where TConcrete : TAbstract
        {
            IoC.Register<TAbstract, TConcrete>();
        }
    }
}
