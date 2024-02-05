using Microsoft.AspNetCore.Identity;
using PageCss.Core.ViewModelsIn;
using PageCss.Core.ViewModelsOut;

namespace PageCss.ApplicationServices.Users
{
    public interface IUserService
    {
        Task<UsersViewModelOut> GetUserAsync(string id);
        Task<IdentityResult> AddUserAsync(UsersViewModelIn userDto);
    }
}
