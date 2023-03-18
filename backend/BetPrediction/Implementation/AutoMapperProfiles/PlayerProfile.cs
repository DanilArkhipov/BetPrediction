using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class PlayerProfile: Profile
{
    public PlayerProfile()
    {
        CreateMap<ProPlayerData, PlayerEntity>();
    }
}