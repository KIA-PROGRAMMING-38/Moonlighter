using UnityEngine;

public class WeaponState : StateMachineBehaviour
{
    protected Weapon weapon;
    protected PlayerInputHandler inputHandler;
    protected bool isAnimationEnded;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weapon = animator.gameObject.GetComponent<Weapon>();
        inputHandler = animator.gameObject.GetComponentInParent<PlayerInputHandler>();
    }

    protected void ChangeState(Animator animator, string currentState, string newState)
    {
        animator.SetBool(currentState, false);
        animator.SetBool(newState, true);
    }
}
