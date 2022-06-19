namespace Models.Entities.Player;

public class AveragePlayerIndicators
{
    public long? AccountId { get; set; }

    public double AssistsCount { get; set; }

    public double Deaths { get; set; }

    public double Gold { get; set; }

    public double KillsCount { get; set; }

    public double TowerDamage { get; set; }

    public double XpPerMin { get; set; }

    public double TotalGold { get; set; }

    public double TotalXp { get; set; }

    public double Kda { get; set; }
}