using UnityEngine;

public class GolemSoldierController : MonsterController
{
    private float _detectRange = 1.5f;
    private float _attackRange = 0.35f;

    protected override bool ShouldBeMoving()
    {
        float distance = GetDistanceToPlayer();

        return CheckRange(_detectRange, distance);
    }

    protected override bool ShouldBeAttack()
    {
        float distance = GetDistanceToPlayer();

        return CheckRange(_attackRange, distance);
    }

    private float GetDistanceToPlayer()
    {
        Vector3 targetPosition = Managers.Dungeon.Player.transform.position;

        Vector3 direction = targetPosition - transform.position;

        return Vector3.Magnitude(direction);
    }

    private bool CheckRange(float range, float distance) => distance < range;
}