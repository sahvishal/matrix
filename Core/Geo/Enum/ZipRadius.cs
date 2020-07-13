using System.ComponentModel;

namespace Falcon.App.Core.Geo.Enum
{
    public enum ZipRadius
    {
        [Description("5 Miles")]
        FiveMiles = 5,

        [Description("10 Miles")]
        TenMiles = 10,

        [Description("15 Miles")]
        FifteenMiles = 15,

        [Description("20 Miles")]
        TwentyMiles = 20,

        [Description("25 Miles")]
        TwentyFiveMiles = 25,

        [Description("50 Miles")]
        FiftyMiles = 50,

        [Description("60 Miles")]
        SixtyMiles = 60,

        //[Description("120 Miles")]
        //OneTwentyMiles = 120,
    }
}
