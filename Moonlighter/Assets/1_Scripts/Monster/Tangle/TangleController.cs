using UnityEngine;

public class TangleController : MonsterController
{
    protected override bool ShouldBeMoving()
    {
        return true;
    }
}