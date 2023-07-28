using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool IsMoving { get; private set; }
    public bool IsAttack { get; private set; }

    private void Update()
    {
        IsMoving = ShouldBeMoving();
        IsAttack = ShouldBeAttack();
    }

    protected virtual bool ShouldBeMoving() 
    {
        return false;
    }

    protected virtual bool ShouldBeAttack() 
    {
        return false;
    }

}