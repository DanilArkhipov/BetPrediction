using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class GameProfile: Profile
{
    public GameProfile()
    {
        CreateMap<GameData, GameEntity>();
    }
}