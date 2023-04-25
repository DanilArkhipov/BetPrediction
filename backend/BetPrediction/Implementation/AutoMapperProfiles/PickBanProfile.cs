using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class PickBanProfile : Profile
{
    public PickBanProfile()
    {
        CreateMap<PickBanData, PickBanEntity>()
            .ForMember(nameof(PickBanEntity.RadiantTeam), opt => opt
                .MapFrom(source => source.Team == 0));
    }
}