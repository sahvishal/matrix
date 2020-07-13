namespace Falcon.App.Core.Domain
{
    // This class is being used because we needed to lock a entity onm two different code blocks.
    public static class CentralLocker
    {
        public static object Locker = new object();

    }
}
