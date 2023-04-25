using Models.Entities;
using Models.Enums;
using Models.ValueObjects;

namespace Models.Player;

/// <summary>
/// Что можно добавить: винрейт, стрик, герои, винрейт на героях, стаж игры
/// </summary>
public class PlayerModel: BaseEntity<Guid>
{
    #region PersonalData

    public string FullName { get; private set; }

    public IReadOnlyCollection<PlayerNickName> NickNames { get; private set; }

    public PrizeMoney Prize { get; private set; }

    public Rating Rating { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public int Age { get; private set; }

    #endregion


    #region TeamData

    public TeamModel Team { get; private set; }

    public TeamRole TeamRole { get; private set; }

    public Position Position { get; private set; }

    #endregion


    public PlayerModel(string fullName, IReadOnlyCollection<PlayerNickName> nickNames, PrizeMoney prize, Rating rating,
        DateOnly birthDate, int age, TeamModel team, TeamRole teamRole, Position position)
    {
        FullName = fullName;
        NickNames = nickNames;
        Prize = prize;
        Rating = rating;
        BirthDate = birthDate;
        Age = age;
        Team = team;
        TeamRole = teamRole;
        Position = position;
    }
}