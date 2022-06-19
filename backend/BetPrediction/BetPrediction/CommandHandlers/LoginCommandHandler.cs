using BetPrediction.Commands;
using Common.Commands;
using Microsoft.AspNetCore.Identity;
using Repositories.Models.Entities;

namespace BetPrediction.CommandHandlers;

public class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;

    public LoginCommandHandler(SignInManager<UserEntity> signInManager, IHttpContextAccessor httpContextAccessor,
        UserManager<UserEntity> userManager)
    {
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task ExecuteAsync(LoginCommand command)
    {
        var res = await _signInManager.PasswordSignInAsync(command.Name, command.Password, true, false);
        if (res.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(command.Name);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("admin"))
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Role", "admin",
                    new CookieOptions { SameSite = SameSiteMode.None, Secure = true });
            else
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Role", "user",
                    new CookieOptions { SameSite = SameSiteMode.None, Secure = true });
        }

        if (res.Succeeded) Console.WriteLine("success");
    }
}