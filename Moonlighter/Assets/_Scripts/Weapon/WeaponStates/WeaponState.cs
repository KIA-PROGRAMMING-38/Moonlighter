using UnityEngine;

public class WeaponState : StateMachineBehaviour
{
    protected Weapon weapon;
    protected PlayerInputHandler inputHandler;
    protected AnimationHandler animHandler;
    protected Player player;
    protected bool isAnimationEnded;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weapon = animator.gameObject.GetComponent<Weapon>();
        animHandler = weapon.AnimHandler;
        inputHandler = animator.gameObject.GetComponentInParent<PlayerInputHandler>();
        player = animator.gameObject.GetComponentInParent<Player>();
        animHandler.AnimationTrigger();
    }

    protected void ChangeState(Animator animator, string currentState, string newState)
    {
        animator.SetBool(currentState, false);
        animator.SetBool(newState, true);
    }

    protected void SetDirection(Animator animator)
    {
        animator.SetFloat(WeaponAnimParams.DIRX, inputHandler.MoveInput.x);
        animator.SetFloat(WeaponAnimParams.DIRY, inputHandler.MoveInput.y);
    }
}
