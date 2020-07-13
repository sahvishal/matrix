
namespace Falcon.App.Core.Users.Domain
{
    public class AccountCoordinatorProfile : User
    {
        public AccountCoordinatorProfile()
        { }

        public AccountCoordinatorProfile(long userId)
            : base(userId)
        { }

        public long AccountCoordinatorId { get; set; }
        public bool IsClinicalCoordinator { get; set; }
    }
}
