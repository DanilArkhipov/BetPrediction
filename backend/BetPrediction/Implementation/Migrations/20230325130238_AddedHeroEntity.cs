using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeroEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_TeamEntity_TeamId1",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity");

            migrationBuilder.RenameTable(
                name: "TeamEntity",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenDotaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenDotaRelativeHeroImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenDotaRelativeHeroIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId1",
                table: "Players",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId1",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_TeamEntity_TeamId1",
                table: "Players",
                column: "TeamId1",
                principalTable: "TeamEntity",
                principalColumn: "Id");
        }
    }
}
