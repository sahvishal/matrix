using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Interfaces
{
    public interface IEmailFactory
    {
        Email CreateEmail(string emailAddress);
    }
}