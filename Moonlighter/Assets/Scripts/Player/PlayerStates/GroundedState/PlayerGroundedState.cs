using UnityEngine;

public class PlayerGroundedState : StateMachineBehaviour
{
    protected PlayerInputHandler inputHandler;
    protected PlayerData playerData;
    protected Rigidbody2D rigid;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputHandler = animator.gameObject.GetComponent<PlayerInputHandler>();
        playerData = animator.gameObject.GetComponent<Player>().PlayerData;
        rigid = animator.gameObject.GetComponent<Rigidbody2D>();
    }
}
