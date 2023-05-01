using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Present.Data;
using Present.Models;
using Present.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Present.Repository.Implement
{
    public class AccountRepository :  IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration, 
            IMapper mapper,
            ChatSystemContext context) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            // ko nen map o day
            var user = _mapper.Map<ApplicationUser>(model);
            return await _userManager.CreateAsync(user,model.PassWord);
        }

        public async Task<string> SignInAsync(SignInModel model)
        {

            var result = await _signInManager.PasswordSignInAsync
                (model.UserName, model.PassWord, false, false);
            var user = await _userManager.FindByNameAsync(model.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            if (!result.Succeeded)
            {
                return string.Empty;

            }
            var authClaims = new List<Claim>
            {
                new Claim("UserName", model.UserName),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
