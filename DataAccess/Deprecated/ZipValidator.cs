using Falcon.DataAccess.Other;
using Falcon.Entity.Other;

namespace Falcon.DataAccess.Deprecated
{
    public class ZipValidator
    {
        public bool DoesRetrievedZipCorrespondToCity(string city, string zipCode, string state, out EZip zipEntity, out string errorMessage)
        {
            var otherDAL = new OtherDAL();
            zipEntity = otherDAL.CheckCityZip(city, zipCode, state);
            int cityId = zipEntity.CityID;
            int zipId = zipEntity.ZipID;

            if (cityId == 0)
            {
                errorMessage = "City name is not valid. Please Try again.";
                return false;
            }
            if (cityId > 0 && zipId == 0)
            {
                errorMessage = "Zip entered for Address is not valid for the corresponding city. Please Try again.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}