using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntitiesForLeaguePlayerGameGameAndPickBan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "Players",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<long>(type: "bigint", nullable: false),
                    Cluster = table.Column<int>(type: "int", nullable: true),
                    GameDuration = table.Column<long>(type: "bigint", nullable: true),
                    Engine = table.Column<int>(type: "int", nullable: true),
                    GameMode = table.Column<int>(type: "int", nullable: true),
                    LeagueId = table.Column<long>(type: "bigint", nullable: true),
                    LobbyType = table.Column<int>(type: "int", nullable: true),
                    MatchSeqNum = table.Column<long>(type: "bigint", nullable: true),
                    RadiantWin = table.Column<bool>(type: "bit", nullable: true),
                    StartTime = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    ReplaySalt = table.Column<long>(type: "bigint", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    SeriesType = table.Column<long>(type: "bigint", nullable: true),
                    Skill = table.Column<int>(type: "int", nullable: true),
                    Patch = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<long>(type: "bigint", nullable: true),
                    ReplayUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiantTeamOpenDotaId = table.Column<long>(type: "bigint", nullable: true),
                    DireTeamOpenDotaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueId = table.Column<long>(type: "bigint", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickBans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPick = table.Column<bool>(type: "bit", nullable: false),
                    OpenDotaHeroId = table.Column<int>(type: "int", nullable: false),
                    RadiantTeam = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    GameId = table.Column<long>(type: "bigint", nullable: true),
                    AssistsCount = table.Column<long>(type: "bigint", nullable: true),
                    CampsStackedCount = table.Column<int>(type: "int", nullable: true),
                    CreepsStackedCount = table.Column<int>(type: "int", nullable: true),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Denies = table.Column<int>(type: "int", nullable: true),
                    FirstTenMinutesIntervalDenies = table.Column<int>(type: "int", nullable: true),
                    SecondTenMinutesIntervalDenies = table.Column<int>(type: "int", nullable: true),
                    ThirdTenMinutesIntervalDenies = table.Column<int>(type: "int", nullable: true),
                    Gold = table.Column<int>(type: "int", nullable: true),
                    GoldPerMinute = table.Column<double>(type: "float", nullable: true),
                    GoldSpent = table.Column<int>(type: "int", nullable: true),
                    FirstTenMinutesIntervalGold = table.Column<int>(type: "int", nullable: true),
                    SecondTenMinutesIntervalGold = table.Column<int>(type: "int", nullable: true),
                    ThirdTenMinutesIntervalGold = table.Column<int>(type: "int", nullable: true),
                    HeroDamage = table.Column<double>(type: "float", nullable: true),
                    HeroHealing = table.Column<double>(type: "float", nullable: true),
                    HeroOpenDotaId = table.Column<int>(type: "int", nullable: true),
                    KillsCount = table.Column<int>(type: "int", nullable: true),
                    LastHits = table.Column<int>(type: "int", nullable: true),
                    LeaverStatus = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    FirstTenMinutesIntervalLastHit = table.Column<int>(type: "int", nullable: true),
                    SecondTenMinutesIntervalLastHit = table.Column<int>(type: "int", nullable: true),
                    ThirdTenMinutesIntervalLastHit = table.Column<int>(type: "int", nullable: true),
                    ObsPlaced = table.Column<int>(type: "int", nullable: true),
                    RunePickUps = table.Column<int>(type: "int", nullable: true),
                    SenPlaced = table.Column<int>(type: "int", nullable: true),
                    Stuns = table.Column<double>(type: "float", nullable: true),
                    TowerDamage = table.Column<double>(type: "float", nullable: true),
                    XpPerMin = table.Column<double>(type: "float", nullable: true),
                    FirstTenMinutesIntervalXp = table.Column<int>(type: "int", nullable: true),
                    SecondTenMinutesIntervalXp = table.Column<int>(type: "int", nullable: true),
                    ThirdTenMinutesIntervalXp = table.Column<int>(type: "int", nullable: true),
                    Win = table.Column<bool>(type: "bit", nullable: true),
                    TotalGold = table.Column<int>(type: "int", nullable: true),
                    TotalXp = table.Column<int>(type: "int", nullable: true),
                    KillsPerMin = table.Column<double>(type: "float", nullable: true),
                    Kda = table.Column<double>(type: "float", nullable: true),
                    Abandons = table.Column<int>(type: "int", nullable: true),
                    NeutralKills = table.Column<int>(type: "int", nullable: true),
                    TowerKills = table.Column<int>(type: "int", nullable: true),
                    CourierKills = table.Column<int>(type: "int", nullable: true),
                    LaneKills = table.Column<int>(type: "int", nullable: true),
                    HeroKills = table.Column<int>(type: "int", nullable: true),
                    ObserverKills = table.Column<int>(type: "int", nullable: true),
                    SentryKills = table.Column<int>(type: "int", nullable: true),
                    RoshanKills = table.Column<int>(type: "int", nullable: true),
                    NecronomiconKills = table.Column<int>(type: "int", nullable: true),
                    AncientKills = table.Column<int>(type: "int", nullable: true),
                    BuyBackCount = table.Column<int>(type: "int", nullable: true),
                    ObserverUses = table.Column<int>(type: "int", nullable: true),
                    SentryUses = table.Column<int>(type: "int", nullable: true),
                    LaneEfficiency = table.Column<double>(type: "float", nullable: true),
                    LaneEfficiencyPct = table.Column<double>(type: "float", nullable: true),
                    Lane = table.Column<int>(type: "int", nullable: true),
                    LaneRole = table.Column<int>(type: "int", nullable: true),
                    IsRoaming = table.Column<bool>(type: "bit", nullable: true),
                    ActionsPerMinute = table.Column<double>(type: "float", nullable: true),
                    RankTier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "PickBans");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
