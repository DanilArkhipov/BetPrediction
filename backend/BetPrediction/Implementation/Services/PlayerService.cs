using AutoMapper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Parsers;
using Parsers.Models.Player;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IPaginatedParser<PlayerShortInfo, BaseTableParserParams> _playerShortInfoParser;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository,
        IPaginatedParser<PlayerShortInfo, BaseTableParserParams> playerShortInfoParser, HttpClient openDotaHttpClient,
        IMapper mapper)
    {
        _playerRepository = playerRepository;
        _playerShortInfoParser = playerShortInfoParser;
        _openDotaHttpClient = openDotaHttpClient;
        _mapper = mapper;
    }

    public async Task LoadPlayersDataToSystem()
    {
        var proPlayersList = await _openDotaHttpClient.GetDataAsync<List<ProPlayerData>>("proPlayers");

        foreach (var player in proPlayersList)
        {
            PlayerEntity? playerEntity = null;
            if (player.Name is not null)
            {
                playerEntity = await _playerRepository.GetPlayerByNameAsync(player.Name!);
            }

            if (playerEntity is not null)
            {
                _mapper.Map(player, playerEntity);
                await _playerRepository.SavePlayerAsync(playerEntity);
            }
            else
            {
                playerEntity = _mapper.Map<PlayerEntity>(player);
                await _playerRepository.SavePlayerAsync(playerEntity);
            }
        }
    }
}