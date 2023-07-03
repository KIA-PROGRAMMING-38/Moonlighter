using UnityEngine;

public class PlayerCharacter : Character
{
    protected override void Awake()
    {
        base.Awake();
        stat = Managers.Data.CharacterStatDataTable["Player"];
    }

    public override void Attack()
    {
        Debug.Log("Player Character Attack..!");
    }

    public override void Die()
    {
        Debug.Log("Player Character Die..");
    }
}