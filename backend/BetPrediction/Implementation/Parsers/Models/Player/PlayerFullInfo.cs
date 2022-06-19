using Repositories.Models.Enums;

namespace Parsers.Models.Player;

public class PlayerFullInfo: PlayerShortInfo
{
    public String BirthDate { get; set; }
    
    public String Role { get; set; }
    
    public String SteamProfileUrl { get; set; }
    
    public String PlayerProfessionalAvatar { get; set; }
}