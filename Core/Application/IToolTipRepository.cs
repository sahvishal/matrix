using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Application
{
    public interface IToolTipRepository
    {
        string GetToolTipContentByTag(ToolTipType toolTipType);
    }
}
