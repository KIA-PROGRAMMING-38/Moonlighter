using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerCharacter player;
    protected PlayerInputHandler input;

    protected Vector2 zeroVelocity = Vector2.zero;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.root.GetComponent<PlayerCharacter>();
        input = animator.transform.root.GetComponent<PlayerInputHandler>();
        player.Rigid.velocity = zeroVelocity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (input.IsMoving)
        {
            OnMove(animator, stateInfo, layerIndex);
        }
        else
        {
            OnIdle(animator, stateInfo, layerIndex);
        }

        if (input.RollInput)
        {
            OnRoll(animator, stateInfo, layerIndex);
        }

        if (input.NormalAttackInput)
        {
            OnNormalAttack(animator, stateInfo, layerIndex);
        }

        if (input.SpecialAttackInput)
        {
            OnSpecialAttack(animator, stateInfo, layerIndex);
        }
        else
        {
            ExitSpecialAttack(animator, stateInfo, layerIndex);
        }
    }

    protected virtual void OnIdle(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnRoll(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void ExitSpecialAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
}