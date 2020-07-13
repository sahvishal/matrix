namespace Falcon.App.Core.Interfaces
{
    public interface IDistanceCalculator
    {
        double DistanceBetweenTwoPoints(float originLatitude, float originLongitude, float destinationLatitude,
                                        float destinationLongitude);
    }
}