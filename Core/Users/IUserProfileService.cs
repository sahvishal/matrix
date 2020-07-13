using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
   public interface IUserProfileService
   {
       ProfileEditModel GetProfileEditModel(long userId);
       void SaveProfile(ProfileEditModel profileEditModel);
   }
}
