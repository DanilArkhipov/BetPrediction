using Models.Enums;

namespace Models.ValueObjects;

public class Rating
{
    public int Count { get; private set; }
    
    public RatingRegion Region { get; private set; }
}