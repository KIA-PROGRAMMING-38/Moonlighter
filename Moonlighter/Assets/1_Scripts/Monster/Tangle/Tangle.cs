using Enums;
using UnityEngine;

public class Tangle : Monster
{
    protected override void Awake()
    {
        base.Awake();
        Stat = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.Tangle];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.gameObject.GetComponent<PlayerCharacter>();

        if(character != null)
        {
            Debug.Log("플레이어를 공격!!");
        }
    }

}