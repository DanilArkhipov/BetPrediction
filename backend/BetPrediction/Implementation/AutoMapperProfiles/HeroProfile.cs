using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class HeroProfile: Profile
{
    public HeroProfile()
    {
        CreateMap<HeroData, HeroEntity>();
    }
}