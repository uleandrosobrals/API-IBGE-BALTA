using API_IBGE.Entities.Dtos;
using API_IBGE.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
namespace API_IBGE.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UserLoginAsync(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName,
                userLoginDto.Password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto userRegister)
        {
            var user = new IdentityUser
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                EmailConfirmed = true
            };

            if (!_roleManager.RoleExistsAsync(userRegister.Role).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = userRegister.Role;
                role.NormalizedName = userRegister.Role.ToLower();
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, userRegister.Role).Wait();
                return true;
            }
            return false;
        }
    }
}
