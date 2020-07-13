using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum RegulatoryState
    {
        Unknown = 1,
        Signed,
        [Description("Not Signed")]
        Not_Signed
    }
}