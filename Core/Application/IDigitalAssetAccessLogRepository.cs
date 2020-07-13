using System;

namespace Falcon.App.Core.Application
{
    public interface IDigitalAssetAccessLogRepository
    {
        bool IsDigitalAssetAccessed(long customerId, DateTime resultReadyDate);
    }
}
