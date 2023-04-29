using UnityEngine;
using EnumValue;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerInputHandler inputHandler;
    protected AnimationHandler animHandler;
    protected Rigidbody2D rigid;
    protected Player player;
    protected PlayerData playerData;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputHandler = animator.transform.root.gameObject.GetComponent<PlayerInputHandler>();
        player = animator.transform.root.gameObject.GetComponent<Player>();
        animHandler = player.AnimHandler;
        playerData = player.PlayerData;
        rigid = animator.transform.root.gameObject.GetComponent<Rigidbody2D>();
        animHandler.AnimationTrigger();
    }

    #region Player State Functions

    protected void ChangeState(Animator animator, PlayerStates currentState, int currentStateParam, int newStateParam)
    {
        player.PrevState = currentState;
        animator.SetBool(currentStateParam, false);
        animator.SetBool(newStateParam, true);
    }

    #endregion
}
