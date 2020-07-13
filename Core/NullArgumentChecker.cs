using System;

namespace Falcon.App.Core
{
    // TODO: Possibly make this into a method attribute class?
    public static class NullArgumentChecker
    {
        public static void CheckIfNull(object objectToCheck, string objectName)
        {
            CheckIfNull(objectToCheck, objectName, string.Empty);
        }
        
        public static void CheckIfNull(object objectToCheck, string objectName, 
            string reasonForNotAllowingNull)
        {
            if (objectToCheck == null)
            {
                throw new ArgumentNullException(objectName, reasonForNotAllowingNull);
            }
        }
    }
}