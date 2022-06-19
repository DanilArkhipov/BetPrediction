using AutoMapper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Models.Entities.Player;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class PlayerGameProfile : Profile
{
    public PlayerGameProfile()
    {
        CreateMap<GamePlayerData, PlayerGameEntity>()
            .ForMember(nameof(PlayerGameEntity.FirstTenMinutesIntervalXp), opt => opt
                .MapFrom(source => source.XpByTimes.GetByIndexOrDefault(9)))
            .ForMember(nameof(PlayerGameEntity.SecondTenMinutesIntervalXp), opt => opt
                .MapFrom(source => source.XpByTimes.GetByIndexOrDefault(19)))
            .ForMember(nameof(PlayerGameEntity.ThirdTenMinutesIntervalXp), opt => opt
                .MapFrom(source => source.XpByTimes.GetByIndexOrDefault(29)))
            .ForMember(nameof(PlayerGameEntity.FirstTenMinutesIntervalDenies), opt => opt
                .MapFrom(source => source.DeniesByTimes.GetByIndexOrDefault(9)))
            .ForMember(nameof(PlayerGameEntity.SecondTenMinutesIntervalDenies), opt => opt
                .MapFrom(source => source.DeniesByTimes.GetByIndexOrDefault(19)))
            .ForMember(nameof(PlayerGameEntity.SecondTenMinutesIntervalDenies), opt => opt
                .MapFrom(source => source.DeniesByTimes.GetByIndexOrDefault(29)))
            .ForMember(nameof(PlayerGameEntity.FirstTenMinutesIntervalGold), opt => opt
                .MapFrom(source => source.GoldByTimes.GetByIndexOrDefault(9)))
            .ForMember(nameof(PlayerGameEntity.SecondTenMinutesIntervalGold), opt => opt
                .MapFrom(source => source.GoldByTimes.GetByIndexOrDefault(19)))
            .ForMember(nameof(PlayerGameEntity.ThirdTenMinutesIntervalGold), opt => opt
                .MapFrom(source => source.GoldByTimes.GetByIndexOrDefault(29)))
            .ForMember(nameof(PlayerGameEntity.FirstTenMinutesIntervalLastHit), opt => opt
                .MapFrom(source => source.LastHitsByTimes.GetByIndexOrDefault(9)))
            .ForMember(nameof(PlayerGameEntity.SecondTenMinutesIntervalLastHit), opt => opt
                .MapFrom(source => source.LastHitsByTimes.GetByIndexOrDefault(19)))
            .ForMember(nameof(PlayerGameEntity.ThirdTenMinutesIntervalLastHit), opt => opt
                .MapFrom(source => source.LastHitsByTimes.GetByIndexOrDefault(29)))
            .ForMember(nameof(PlayerGameEntity.Win), opt => opt
                .MapFrom(source => source.Win == 1))
            .ForMember(nameof(PlayerGameEntity.GameId), opt => opt
                .MapFrom(source => source.MatchId))
            .ForMember(nameof(PlayerGameEntity.DoubleKillsCount), opt => opt
                .MapFrom(source => source.MultiKills.DoubleKillsCount))
            .ForMember(nameof(PlayerGameEntity.TripleKillsCount), opt => opt
                .MapFrom(source => source.MultiKills.TripleKillsCount))
            .ForMember(nameof(PlayerGameEntity.UltraKillsCount), opt => opt
                .MapFrom(source => source.MultiKills.UltraKillsCount))
            .ForMember(nameof(PlayerGameEntity.RampagesCount), opt => opt
                .MapFrom(source => source.MultiKills.RampagesCount));

        CreateMap<PlayerGameEntity, PlayerIndicators>();
    }
}