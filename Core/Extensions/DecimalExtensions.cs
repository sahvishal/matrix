namespace Falcon.App.Core.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToAbsoluteValue(this decimal value)
        {
            if (value < decimal.Zero) return (-1 * value);
            
            return value;
        }
    }
}
