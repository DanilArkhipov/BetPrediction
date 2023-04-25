namespace Services;

public interface IGameService
{
    Task LoadGamesToSystem(DateOnly dateStart);
}