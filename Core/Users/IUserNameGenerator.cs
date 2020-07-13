using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users
{
    public interface IUserNameGenerator
    {
        string Generate(Name fullName);
        string Generate(string firstName, string lastName);
    }
}