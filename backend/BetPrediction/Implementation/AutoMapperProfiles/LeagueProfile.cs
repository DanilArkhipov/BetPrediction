using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class LeagueProfile: Profile
{
    public LeagueProfile()
    {
        CreateMap<LeagueData, LeagueEntity>();
    }
}