namespace Falcon.App.Core.Application
{
    public interface IPopulator<TFrom, TTo> where TTo : class
    {
        void Populate(TFrom source, TTo destination);
    }
}