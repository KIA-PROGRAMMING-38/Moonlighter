using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool IsIdle { get; private set; }
    public bool IsMoving { get; private set; }
    public bool IsAttack { get; private set; }

    private void Update()
    {
        IsIdle = ShouldBeIdle();
        IsMoving = ShouldBeMoving();
        IsAttack = ShouldBeAttack();
    }

    protected virtual bool ShouldBeIdle() 
    {
        return false;
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