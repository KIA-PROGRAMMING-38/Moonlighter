using UnityEngine;

public class GolemSoldierAttackState : GolemSoldierState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (golemSoldier.IsHit == false)
            rigid.velocity = Vector2.zero;
    }

}
