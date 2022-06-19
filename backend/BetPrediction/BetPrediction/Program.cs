using BetPrediction.CommandHandlers;
using BetPrediction.Commands;
using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using BetPrediction.QueryHandlers;
using Common.Commands;
using Common.Queries;
using Implementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string MyAllowSpecificOrigins = "sdf";
builder.Services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
    policy => { policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials(); }));

builder.Services.AddControllers(options => { });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());
InfrastructureConfiguration.ConfigureServices(builder.Services);
builder.Services.AddScoped<SignInManager<UserEntity>>();
builder.Services.AddScoped<ISecurityStampValidator, SecurityStampValidator<UserEntity>>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddCookie(IdentityConstants.ApplicationScheme, o =>
    {
        o.LoginPath = new PathString("/Authorization/Login");
        o.Cookie.HttpOnly = false;
        o.Cookie.SameSite = SameSiteMode.None;
        o.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
        };
    })
    .AddCookie(IdentityConstants.ExternalScheme, o =>
    {
        o.Cookie.Name = IdentityConstants.ExternalScheme;
        o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    })
    .AddCookie(IdentityConstants.TwoFactorRememberMeScheme, o =>
    {
        o.Cookie.Name = IdentityConstants.TwoFactorRememberMeScheme;
        o.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = SecurityStampValidator.ValidateAsync<ITwoFactorSecurityStampValidator>
        };
    })
    .AddCookie(IdentityConstants.TwoFactorUserIdScheme, o =>
    {
        o.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
        o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<ICommandHandler<LoadDataToSystemCommand>, LoadDataToSystemCommandHandler>();
builder.Services.AddScoped<ICommandHandler<TrainClassifiersCommand>, TrainClassifiersCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RegisterCommand>, RegisterCommandHandler>();
builder.Services.AddScoped<ICommandHandler<LoginCommand>, LoginCommandHandler>();
builder.Services.AddScoped<ICommandHandler<GenerateHeroMatrixForPeriodCommand>, GenerateHeroMatrixCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<GeneratePickBansDataSetForPeriodCommand>,
        GeneratePickBansDataSetForPeriodCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<GenerateDataForPickBansPredictionModelTrainingCommand>,
        GenerateDataForPickBansPredictionModelTrainingCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<GeneratePlayerIndicatorsDataSetForPeriodCommand>,
        GeneratePlayerIndicatorsDataSetForPeriodCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<GenerateAveragePlayerIndicatorsDataSetForPeriodCommand>,
        GenerateAveragePlayerIndicatorsDataSetForPeriodCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<GenerateGamesDataSetForPeriodCommand>,
        GenerateGamesDataSetForPeriodCommandHandler>();
builder.Services
    .AddScoped<ICommandHandler<PredictCommand, Tuple<int, int>>,
        PredictCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>>, GetProPlayersQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetTeamsQuery, BaseListModel<TeamsDto>>, GetTeamsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAdminLogsQuery, BaseListModel<AdminLogsDto>>, GetAdminLogsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetPredictionDataQuery, PredictionDataDto>, GetPredictionDataQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapPost("/Authorization/Registration",
    async ([FromBody] RegisterCommand command, ICommandHandler<RegisterCommand> handler) =>
    {
        await handler.ExecuteAsync(command);
    });

app.MapPost("/Authorization/Login",
    async ([FromBody] LoginCommand command, ICommandHandler<LoginCommand> handler) =>
    {
        await handler.ExecuteAsync(command);
    });

app.MapPost("/Administration/LoadDataToSystem",
    async ([FromBody] LoadDataToSystemCommand command, ICommandHandler<LoadDataToSystemCommand> handler) =>
    {
        await handler.ExecuteAsync(command);
    });

app.MapPost("/Administration/TrainClassifiers",
    async ([FromBody] TrainClassifiersCommand command, ICommandHandler<TrainClassifiersCommand> handler) =>
    {
        await handler.ExecuteAsync(command);
    });

app.MapPost("/Administration/GenerateHeroMatrixForPeriod",
    async ([FromBody] GenerateHeroMatrixForPeriodCommand command,
        ICommandHandler<GenerateHeroMatrixForPeriodCommand> generateHeroMatrixCommandHandler) =>
    {
        await generateHeroMatrixCommandHandler.ExecuteAsync(command);
    });

app.MapPost("/Administration/GeneratePickBansDataSetForPeriod",
    async ([FromBody] GeneratePickBansDataSetForPeriodCommand command,
        ICommandHandler<GeneratePickBansDataSetForPeriodCommand> commandHandler) =>
    {
        await commandHandler.ExecuteAsync(command);
    });

app.MapPost("/Administration/GenerateDataForPickBansPredictionModelTraining",
    async ([FromBody] GenerateDataForPickBansPredictionModelTrainingCommand command,
        ICommandHandler<GenerateDataForPickBansPredictionModelTrainingCommand> commandHandler) =>
    {
        await commandHandler.ExecuteAsync(command);
    });

app.MapPost("/Administration/GeneratePlayerIndicatorsDataSetForPeriod",
    async ([FromBody] GeneratePlayerIndicatorsDataSetForPeriodCommand command,
        ICommandHandler<GeneratePlayerIndicatorsDataSetForPeriodCommand> commandHandler) =>
    {
        await commandHandler.ExecuteAsync(command);
    });

app.MapPost("/Administration/GenerateAveragePlayerIndicatorsDataSetForPeriod",
    async ([FromBody] GenerateAveragePlayerIndicatorsDataSetForPeriodCommand command,
        ICommandHandler<GenerateAveragePlayerIndicatorsDataSetForPeriodCommand> commandHandler) =>
    {
        await commandHandler.ExecuteAsync(command);
    });
app.MapPost("/Administration/GenerateGamesDataSetForPeriodCommand", async (
    [FromBody] GenerateGamesDataSetForPeriodCommand command,
    ICommandHandler<GenerateGamesDataSetForPeriodCommand> commandHandler) =>
{
    await commandHandler.ExecuteAsync(command);
});

app.MapPost("/Prediction/Predict", async (
    [FromBody] PredictCommand command,
    ICommandHandler<PredictCommand, Tuple<int, int>> commandHandler) =>
{
    await commandHandler.ExecuteAsync(command);
});

app.MapGet("/Administration/GetLogs",
    async (int page, int pageSize,
        [FromServices] IQueryHandler<GetAdminLogsQuery, BaseListModel<AdminLogsDto>> handler) =>
    {
        var query = new GetAdminLogsQuery
        {
            Page = page,
            PageSize = pageSize
        };
        return await handler.ExecuteAsync(query);
    });


app.MapGet("/Players/GetProPlayers",
    async (int page, int pageSize,
        [FromServices] IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>> getProPlayersQueryHandler) =>
    {
        var query = new GetProPlayersQuery
        {
            Page = page,
            PageSize = pageSize
        };
        return await getProPlayersQueryHandler.ExecuteAsync(query);
    });

app.MapGet("/Teams/GetTeams",
    async (int page, int pageSize,
        [FromServices] IQueryHandler<GetTeamsQuery, BaseListModel<TeamsDto>> getTeamsQueryHandler) =>
    {
        var query = new GetTeamsQuery
        {
            Page = page,
            PageSize = pageSize
        };
        return await getTeamsQueryHandler.ExecuteAsync(query);
    });
app.MapGet("/Prediction/GetData",
    async ([FromServices] IQueryHandler<GetPredictionDataQuery, PredictionDataDto> queryHandler) =>
    {
        var query = new GetPredictionDataQuery();
        return await queryHandler.ExecuteAsync(query);
    });

app.Run();