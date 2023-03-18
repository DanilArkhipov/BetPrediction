using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class TeamProfile: Profile
{
    public TeamProfile()
    {
        CreateMap<TeamData, TeamEntity>();
    }
}