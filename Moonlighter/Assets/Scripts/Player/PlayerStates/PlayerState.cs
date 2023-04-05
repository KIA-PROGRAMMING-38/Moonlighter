using UnityEngine;
using EnumValue;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerInputHandler inputHandler;
    protected Rigidbody2D rigid;
    protected Player player;
    protected PlayerData playerData;

    protected bool isAnimationEnded;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputHandler = animator.gameObject.GetComponent<PlayerInputHandler>();
        player = animator.gameObject.GetComponent<Player>();
        playerData = player.PlayerData;
        rigid = animator.gameObject.GetComponent<Rigidbody2D>();

        isAnimationEnded = false;
    }

    #region Player State Functions

    protected void ChangeState(Animator animator, PlayerStates state, string currentState, string newState)
    {
        player.PrevState = state;
        animator.SetBool(currentState, false);
        animator.SetBool(newState, true);
    }

    #endregion
}
