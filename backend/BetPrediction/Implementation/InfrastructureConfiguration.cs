using Implementation.AutoMapperProfiles;
using Implementation.Data;
using Implementation.Parsers;
using Implementation.Repositories;
using Implementation.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parsers;
using Parsers.Models.Player;
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

        serviceCollection.AddScoped<ILoadDataService, LoadDataService>();

        serviceCollection.AddScoped<IPaginatedParser<PlayerShortInfo, BaseTableParserParams>, PlayerShortInfoParser>();

        serviceCollection.AddHttpClient(Constants.OpenDotaApiHttpClientName,
            client => { client.BaseAddress = new Uri("https://api.opendota.com/api/"); }
        );

        serviceCollection.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new PlayerProfile());
            cfg.AddProfile(new TeamProfile());
        });
    }
}