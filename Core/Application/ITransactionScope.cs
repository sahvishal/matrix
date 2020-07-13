using System;

namespace Falcon.App.Core.Application
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}