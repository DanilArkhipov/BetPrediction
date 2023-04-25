namespace Models.Player;

public class PlayerNickName
{
    public string NickName { get; private set; }
    
    public bool IsActualNickName { get; private set; }

    public PlayerNickName(string nickName, bool isActualNickName)
    {
        NickName = nickName;
        IsActualNickName = isActualNickName;
    }
}