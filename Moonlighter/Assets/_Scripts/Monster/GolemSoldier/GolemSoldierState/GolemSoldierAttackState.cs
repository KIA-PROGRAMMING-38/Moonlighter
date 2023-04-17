using UnityEngine;

public class GolemSoldierAttackState : GolemSoldierState
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rigid.velocity = Vector2.zero;
    }
}
