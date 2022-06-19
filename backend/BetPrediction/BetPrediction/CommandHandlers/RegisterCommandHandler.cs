using BetPrediction.Commands;
using Common.Commands;
using Microsoft.AspNetCore.Identity;
using Repositories.Models.Entities;

namespace BetPrediction.CommandHandlers;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;

    public RegisterCommandHandler(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task ExecuteAsync(RegisterCommand command)
    {
        var user = new UserEntity();
        user.UserName = command.Name;
        var result = await _userManager.CreateAsync(user, command.Password);
        if (result.Succeeded) await _signInManager.SignInAsync(user, true);
    }
}