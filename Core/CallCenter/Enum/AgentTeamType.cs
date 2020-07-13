using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.Enum
{
    public enum AgentTeamType
    {
        [Description("--Select--")]             //DropDown is populated via Enum , so added it here.
        Select = 0,
        [Description("Inbound")]
        InBound = 353,
        [Description("Outbound")]
        OutBound,
        [Description("Confirmation")]
        Confirmation,
        [Description("HRA")]
        Hra
    }
}
