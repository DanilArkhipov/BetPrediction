using Models.Enums;

namespace Models.ValueObjects;

public class PrizeMoney
{
    public double Count { get; private set; }
    
    public PrizeCurrency Currency { get; private set; }

    public PrizeMoney(double count, PrizeCurrency currency)
    {
        Count = count;
        Currency = currency;
    }
}