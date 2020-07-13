using Newtonsoft.Json;

namespace Falcon.App.Core.Extensions
{
    public static class ObjectCloneExtension
    {
        public static T Clone<T>(T objectToClone)
        {
            if (ReferenceEquals(objectToClone, null))
            {
                return default(T);
            }

            var serialized = JsonConvert.SerializeObject(objectToClone);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
