using UnityEngine;

public class MonsterState : StateMachineBehaviour
{
    protected Monster monster;
    protected MonsterController controller;
    protected Rigidbody2D target;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.transform.root.GetComponent<Monster>();
        controller = animator.transform.root.GetComponent<MonsterController>();
        target = Managers.Dungeon.Player.Rigid;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller.IsIdle)
        {
            OnIdle(animator, stateInfo, layerIndex);
        }

        if (controller.IsMoving)
        {
            OnMove(animator, stateInfo, layerIndex);
        }

        if (controller.IsAttack)
        {
            OnAttack(animator, stateInfo, layerIndex);
        }
    }

    protected virtual void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
}