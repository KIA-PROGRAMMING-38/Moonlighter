using UnityEngine;

public class GolemSoldierMoveState : MonsterState
{
    protected override void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Idle);
    }

    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 velocity = (target.position - monster.Rigid.position).normalized;

        animator.SetVector2(AnimParameters.MoveX, AnimParameters.MoveY, velocity);
               
        monster.Rigid.velocity = velocity * monster.Stat.MoveSpeed;
    }

    protected override void OnAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(AnimParameters.Attack);
    }
}