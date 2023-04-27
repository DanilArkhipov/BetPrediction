using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchesCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TotalPrize",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvatarFullUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarMediumUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cheese",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FantasyRole",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Players",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPro",
                table: "Players",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "Players",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalCountryCode",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockedUntil",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayersMatchHistoryLastUpdateDate",
                table: "Players",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayersMatchHistoryUnavailable",
                table: "Players",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SteamId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SteamName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamTag",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AvatarFullUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AvatarMediumUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Cheese",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FantasyRole",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsPro",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LocalCountryCode",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LockedUntil",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayersMatchHistoryLastUpdateDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayersMatchHistoryUnavailable",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SteamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SteamName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamTag",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchesCount",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TotalPrize",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
