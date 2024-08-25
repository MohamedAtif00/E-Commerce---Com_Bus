using E_Commerce.Identity.Domain.Model.UserAggre;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Identity.Application
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User user, UserManager<User> AppManager);
    }
}