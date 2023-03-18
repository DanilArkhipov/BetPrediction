using BetPrediction.CommandHandlers;
using BetPrediction.Commands;
using Common.Commands;
using Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InfrastructureConfiguration.ConfigureServices(builder.Services);
builder.Services.AddScoped<ICommandHandler<LoadDataToSystem>, LoadDataToSystemCommandHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/Players/Fetch",
    async (ICommandHandler<LoadDataToSystem> updatePlayersCommand) =>
    {
        await updatePlayersCommand.ExecuteAsync(new LoadDataToSystem());
    });

app.Run();