using System;

namespace Falcon.App.Core.Application
{
    public interface IDependencyInjectionHelper
    {
        T Resolve<T>();
        object Resolve(Type obj);
        T Resolve<T>(string name);
        void Register<TAbstract, TConcrete>() where TConcrete : TAbstract;
    }

}
