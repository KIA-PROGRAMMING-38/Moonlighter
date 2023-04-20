using UnityEngine;

public class GolemSoldierTraceState : GolemSoldierState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDestination();

        SetDirection(animator);

        moveVelocity = (target.position - rigid.position).normalized;

        if (Mathf.Abs(Vector2.Distance(rigid.position, destination)) < canAttackRange)
        {
            animator.SetTrigger(MonsterAnimParams.ATTACK);
        }
        else
        {
            if(golemSoldier.IsHit == false)
                rigid.velocity = moveVelocity * speedCorrectionValue;
        }

    }
}
