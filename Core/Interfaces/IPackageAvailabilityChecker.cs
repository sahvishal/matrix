namespace Falcon.App.Core.Interfaces
{
    public interface IPackageAvailabilityChecker
    {
        bool PackageIsAvailableForEvent(int packageId, int eventId);
    }
}