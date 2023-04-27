using BetPrediction.CommandHandlers;
using BetPrediction.Commands;
using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using BetPrediction.QueryHandlers;
using Common.Commands;
using Common.Queries;
using Implementation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InfrastructureConfiguration.ConfigureServices(builder.Services);
builder.Services.AddScoped<ICommandHandler<LoadDataToSystem>, LoadDataToSystemCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>>, GetProPlayersQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetTeamsQuery, BaseListModel<TeamsDto>>, GetTeamsQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.MapPost("/Administration/LoadDataToSystem",
    async (ICommandHandler<LoadDataToSystem> updatePlayersCommand) =>
    {
        await updatePlayersCommand.ExecuteAsync(new LoadDataToSystem());
    });

app.MapGet("/Players/GetProPlayers",
    async (int page, int pageSize,
        [FromServices] IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>> getProPlayersQueryHandler) =>
    {
        var query = new GetProPlayersQuery()
        {
            Page = page,
            PageSize = pageSize,
        };
        return await getProPlayersQueryHandler.ExecuteAsync(query);
    });

app.MapGet("/Teams/GetTeams",
    async (int page, int pageSize,
        [FromServices] IQueryHandler<GetTeamsQuery, BaseListModel<TeamsDto>> getTeamsQueryHandler) =>
    {
        var query = new GetTeamsQuery()
        {
            Page = page,
            PageSize = pageSize,
        };
        return await getTeamsQueryHandler.ExecuteAsync(query);
    });

app.Run();