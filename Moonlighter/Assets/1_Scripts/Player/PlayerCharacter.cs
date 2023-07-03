using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Attack()
    {
        Debug.Log("Player Character Attack..!");
    }

    public override void Die()
    {
        Debug.Log("Player Character Die..");
    }
}