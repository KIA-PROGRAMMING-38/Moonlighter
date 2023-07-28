using System.IO;
using UnityEngine;

public class DungeonManager
{
    private const string PLAYER_PATH = "PlayerCharacter/PlayerCharacter";

    public PlayerCharacter Player { get; private set; }

    public void Init() 
    {
        if(Player == null)
        {
            GameObject go = GameObject.Find("PlayerCharacter");
            if(go == null)
            {
                go = Managers.Resource.Instantiate(Path.Combine(PLAYER_PATH));
            }
            Player = go.GetComponent<PlayerCharacter>();
        }
    }
}