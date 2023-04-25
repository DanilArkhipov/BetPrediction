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
    private readonly HttpClient _openDotaHttpClient;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository, IHttpClientFactory httpClientFactory,
        IMapper mapper)
    {
        _playerRepository = playerRepository;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
        _mapper = mapper;
    }

    public async Task LoadPlayersDataToSystem()
    {
        var proPlayersList = await _openDotaHttpClient.GetDataAsync<List<ProPlayerData>>("proPlayers");
        var updatedPlayers = new List<PlayerEntity>(proPlayersList.Count);

        foreach (var player in proPlayersList)
        {
            var playerEntity = await _playerRepository.GetPlayerByAccountId(player.AccountId);
            

            if (playerEntity is not null)
            {
                _mapper.Map(player, playerEntity);
            }
            else
            {
                playerEntity = _mapper.Map<PlayerEntity>(player);
            }
            
            updatedPlayers.Add(playerEntity);
        }

        await _playerRepository.SavePlayersAsync(updatedPlayers);
    }
}