using Implementation.AutoMapperProfiles;
using Implementation.Data;
using Implementation.Parsers;
using Implementation.Parsers.Models.Match;
using Implementation.Repositories;
using Implementation.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parsers;
using Repositories;
using Services;

namespace Implementation;

public static class InfrastructureConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
//TODO Вынести строку подключения в переменные коружения, чтобы не светить в репозитории
        serviceCollection.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(
                @"Server=DESKTOP-520CUVL;Database=BetPredictionDB;Trusted_Connection=True;TrustServerCertificate=true;"));

        serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();
        serviceCollection.AddScoped<ITeamRepository, TeamRepository>();
        serviceCollection.AddScoped<IHeroRepository, HeroRepository>();
        serviceCollection.AddScoped<IPatchRepository, PatchRepository>();
        serviceCollection.AddScoped<IPlayerGameRepository, PlayerGameRepository>();
        serviceCollection.AddScoped<IPickBanRepository, PickBanRepository>();
        serviceCollection.AddScoped<ILeagueRepository, LeagueRepository>();
        serviceCollection.AddScoped<IGameRepository, GameRepository>();
        
        serviceCollection.AddScoped<IPlayerService, PlayerService>();
        serviceCollection.AddScoped<ITeamService, TeamService>();
        serviceCollection.AddScoped<IGameService, GameService>();
        serviceCollection.AddScoped<IHeroServices, HeroService>();
        serviceCollection.AddScoped<IPatchService, PatchService>();

        //serviceCollection.AddScoped<IPaginatedParser<PlayerShortInfo, BaseTableParserParams>, PlayerShortInfoParser>();
        serviceCollection.AddScoped<IPaginatedParser<MatchesListItem, BaseTableParserParams>, MatchesListParser>();
        serviceCollection.AddScoped<IParser<MatchInfo, BaseParserParams>, MatchParser>();

        serviceCollection.AddHttpClient(Constants.OpenDotaApiHttpClientName,
            client => { client.BaseAddress = new Uri("https://api.opendota.com/api/"); }
        );

        serviceCollection.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new PlayerProfile());
            cfg.AddProfile(new TeamProfile());
            cfg.AddProfile(new HeroProfile());
            cfg.AddProfile(new PatchProfile());
            cfg.AddProfile(new PlayerGameProfile());
            cfg.AddProfile(new PickBanProfile());
            cfg.AddProfile(new LeagueProfile());
            cfg.AddProfile(new GameProfile());
        });
    }
}