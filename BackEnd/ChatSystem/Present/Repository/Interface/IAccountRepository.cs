using Microsoft.AspNetCore.Identity;
using Present.Data;
using Present.Models;

namespace Present.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<string> SignInAsync(SignInModel model);
    }
}
