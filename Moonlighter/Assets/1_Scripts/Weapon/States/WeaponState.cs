using UnityEngine;

public class WeaponState : StateMachineBehaviour
{
    protected PlayerInputHandler input;
    protected PlayerCharacter player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.root.GetComponent<PlayerCharacter>();
        input = animator.transform.root.GetComponent<PlayerInputHandler>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (input.IsMoving)
        {
            OnMove(animator, stateInfo, layerIndex);
        }

        if (input.NormalAttackInput)
        {
            OnNormalAttack(animator, stateInfo, layerIndex);
        }
    }

    protected virtual void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
}