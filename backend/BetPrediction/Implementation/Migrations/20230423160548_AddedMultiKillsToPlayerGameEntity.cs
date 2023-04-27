using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation.Migrations
{
    /// <inheritdoc />
    public partial class AddedMultiKillsToPlayerGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoubleKillsCount",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RampagesCount",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripleKillsCount",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltraKillsCount",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoubleKillsCount",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "RampagesCount",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "TripleKillsCount",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "UltraKillsCount",
                table: "PlayerGames");
        }
    }
}
