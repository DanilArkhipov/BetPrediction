﻿// <auto-generated />
using System;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Implementation.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Repositories.Models.Entities.AdminLogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndPeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartPeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminLogs");
                });

            modelBuilder.Entity("Repositories.Models.Entities.GameEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Cluster")
                        .HasColumnType("int");

                    b.Property<long?>("DireTeamOpenDotaId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Engine")
                        .HasColumnType("int");

                    b.Property<long?>("GameDuration")
                        .HasColumnType("bigint");

                    b.Property<int?>("GameMode")
                        .HasColumnType("int");

                    b.Property<long?>("LeagueId")
                        .HasColumnType("bigint");

                    b.Property<int?>("LobbyType")
                        .HasColumnType("int");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MatchSeqNum")
                        .HasColumnType("bigint");

                    b.Property<int?>("Patch")
                        .HasColumnType("int");

                    b.Property<long?>("RadiantTeamOpenDotaId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("RadiantWin")
                        .HasColumnType("bit");

                    b.Property<long?>("Region")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReplaySalt")
                        .HasColumnType("bigint");

                    b.Property<string>("ReplayUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SeriesId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SeriesType")
                        .HasColumnType("bigint");

                    b.Property<int?>("Skill")
                        .HasColumnType("int");

                    b.Property<long?>("StartTime")
                        .HasColumnType("bigint");

                    b.Property<int?>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Repositories.Models.Entities.HeroEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpenDotaId")
                        .HasColumnType("int");

                    b.Property<string>("OpenDotaRelativeHeroIconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenDotaRelativeHeroImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Repositories.Models.Entities.LeagueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("LeagueId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Repositories.Models.Entities.PatchEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpenDotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patches");
                });

            modelBuilder.Entity("Repositories.Models.Entities.PickBanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPick")
                        .HasColumnType("bit");

                    b.Property<int>("OpenDotaHeroId")
                        .HasColumnType("int");

                    b.Property<bool>("RadiantTeam")
                        .HasColumnType("bit");

                    b.Property<bool>("Win")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PickBans");
                });

            modelBuilder.Entity("Repositories.Models.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Cheese")
                        .HasColumnType("int");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FantasyRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPro")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocalCountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LockedUntil")
                        .HasColumnType("int");

                    b.Property<int>("MatchesCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerRole")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PlayersMatchHistoryLastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PlayersMatchHistoryUnavailable")
                        .HasColumnType("bit");

                    b.Property<string>("ProfessionalAvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SteamId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SteamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeamId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrizesInDollars")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TeamId1");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Repositories.Models.Entities.PlayerGameEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Abandons")
                        .HasColumnType("int");

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<double?>("ActionsPerMinute")
                        .HasColumnType("float");

                    b.Property<int?>("AncientKills")
                        .HasColumnType("int");

                    b.Property<long?>("AssistsCount")
                        .HasColumnType("bigint");

                    b.Property<int?>("BuyBackCount")
                        .HasColumnType("int");

                    b.Property<int?>("CampsStackedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CourierKills")
                        .HasColumnType("int");

                    b.Property<int?>("CreepsStackedCount")
                        .HasColumnType("int");

                    b.Property<int?>("Deaths")
                        .HasColumnType("int");

                    b.Property<int?>("Denies")
                        .HasColumnType("int");

                    b.Property<int>("DoubleKillsCount")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTenMinutesIntervalDenies")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTenMinutesIntervalGold")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTenMinutesIntervalLastHit")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTenMinutesIntervalXp")
                        .HasColumnType("int");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Gold")
                        .HasColumnType("int");

                    b.Property<double?>("GoldPerMinute")
                        .HasColumnType("float");

                    b.Property<int?>("GoldSpent")
                        .HasColumnType("int");

                    b.Property<double?>("HeroDamage")
                        .HasColumnType("float");

                    b.Property<double?>("HeroHealing")
                        .HasColumnType("float");

                    b.Property<int?>("HeroKills")
                        .HasColumnType("int");

                    b.Property<int?>("HeroOpenDotaId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsRadiant")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRoaming")
                        .HasColumnType("bit");

                    b.Property<double?>("Kda")
                        .HasColumnType("float");

                    b.Property<int?>("KillsCount")
                        .HasColumnType("int");

                    b.Property<double?>("KillsPerMin")
                        .HasColumnType("float");

                    b.Property<int?>("Lane")
                        .HasColumnType("int");

                    b.Property<double?>("LaneEfficiency")
                        .HasColumnType("float");

                    b.Property<double?>("LaneEfficiencyPct")
                        .HasColumnType("float");

                    b.Property<int?>("LaneKills")
                        .HasColumnType("int");

                    b.Property<int?>("LaneRole")
                        .HasColumnType("int");

                    b.Property<int?>("LastHits")
                        .HasColumnType("int");

                    b.Property<int?>("LeaverStatus")
                        .HasColumnType("int");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("NecronomiconKills")
                        .HasColumnType("int");

                    b.Property<int?>("NeutralKills")
                        .HasColumnType("int");

                    b.Property<int?>("ObsPlaced")
                        .HasColumnType("int");

                    b.Property<int?>("ObserverKills")
                        .HasColumnType("int");

                    b.Property<int?>("ObserverUses")
                        .HasColumnType("int");

                    b.Property<int>("RampagesCount")
                        .HasColumnType("int");

                    b.Property<int?>("RankTier")
                        .HasColumnType("int");

                    b.Property<int?>("RoshanKills")
                        .HasColumnType("int");

                    b.Property<int?>("RunePickUps")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTenMinutesIntervalDenies")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTenMinutesIntervalGold")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTenMinutesIntervalLastHit")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTenMinutesIntervalXp")
                        .HasColumnType("int");

                    b.Property<int?>("SenPlaced")
                        .HasColumnType("int");

                    b.Property<int?>("SentryKills")
                        .HasColumnType("int");

                    b.Property<int?>("SentryUses")
                        .HasColumnType("int");

                    b.Property<double?>("Stuns")
                        .HasColumnType("float");

                    b.Property<int?>("ThirdTenMinutesIntervalDenies")
                        .HasColumnType("int");

                    b.Property<int?>("ThirdTenMinutesIntervalGold")
                        .HasColumnType("int");

                    b.Property<int?>("ThirdTenMinutesIntervalLastHit")
                        .HasColumnType("int");

                    b.Property<int?>("ThirdTenMinutesIntervalXp")
                        .HasColumnType("int");

                    b.Property<int?>("TotalGold")
                        .HasColumnType("int");

                    b.Property<int?>("TotalXp")
                        .HasColumnType("int");

                    b.Property<double?>("TowerDamage")
                        .HasColumnType("float");

                    b.Property<int?>("TowerKills")
                        .HasColumnType("int");

                    b.Property<int>("TripleKillsCount")
                        .HasColumnType("int");

                    b.Property<int>("UltraKillsCount")
                        .HasColumnType("int");

                    b.Property<bool?>("Win")
                        .HasColumnType("bit");

                    b.Property<double?>("XpPerMin")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PlayerGames");
                });

            modelBuilder.Entity("Repositories.Models.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LastMatchTimeStamp")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TeamRating")
                        .HasColumnType("float");

                    b.Property<string>("TeamTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalLosses")
                        .HasColumnType("int");

                    b.Property<int>("TotalWins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Repositories.Models.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Repositories.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Repositories.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositories.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Repositories.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Models.Entities.PlayerEntity", b =>
                {
                    b.HasOne("Repositories.Models.Entities.TeamEntity", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId1");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Repositories.Models.Entities.TeamEntity", b =>
                {
                    b.Navigation("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
