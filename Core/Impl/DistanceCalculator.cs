using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Impl
{
    [DefaultImplementation]
    public class DistanceCalculator : IDistanceCalculator
    {
        // TODO: The arguments are converted to float since there was a problem with a zipcode:74804.
        // Now its working fine for all the zipcodes.
        public double DistanceBetweenTwoPoints(float originLatitude, float originLongitude,
            float destinationLatitude, float destinationLongitude)
        {
            //const float convertConstant = 0.0174532925f; // What is this constant?
            //return 3956*Math.Acos
            //(
            //    (Math.Sin(originLatitude*convertConstant)*Math.Sin(destinationLatitude*convertConstant)) +
            //    (Math.Cos(originLatitude*convertConstant) * Math.Cos(destinationLatitude*convertConstant)
            //        * Math.Cos((destinationLongitude - originLongitude)*convertConstant))
            //);

            if (originLatitude == 0 || originLongitude == 0 || destinationLatitude == 0 || destinationLongitude == 0)
                return -0.0009;

            if ((originLongitude == destinationLongitude && originLatitude == destinationLatitude)) return 0;

            const float convertConstant = 57.30f; // What is this constant?
            double distance = 3956 * Math.Acos
            (
                (Math.Sin(originLatitude / convertConstant) * Math.Sin(destinationLatitude / convertConstant)) +
                (Math.Cos(originLatitude / convertConstant) * Math.Cos(destinationLatitude / convertConstant)
                    * Math.Cos((destinationLongitude - originLongitude) / convertConstant))
            );

            if (distance < 0) distance = distance * -1;

            return distance;
        }
    }
}