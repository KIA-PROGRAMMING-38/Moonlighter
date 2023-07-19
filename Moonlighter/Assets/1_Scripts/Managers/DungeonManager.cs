public class DungeonManager
{
    private const string PLAYER_PATH = "PlayerCharacter/PlayerCharacter";

    public PlayerCharacter Player { get; private set; }

    public void Init() 
    {
        if(Player == null)
        {
            Player = Managers.Resource.Instantiate(PLAYER_PATH).GetComponent<PlayerCharacter>();
        }
    }
}