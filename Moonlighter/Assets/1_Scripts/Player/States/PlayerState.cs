using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerCharacter player;
    protected PlayerInputHandler input;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.root.GetComponent<PlayerCharacter>();
        input = animator.transform.root.GetComponent<PlayerInputHandler>();
    }

    protected void ExitCurrentState(int currentState)
    {
        player.Anim.SetBool(currentState, false);
    }

    protected void ChangeToNextState(int nextState)
    {
        player.Anim.SetBool(nextState, true);
    }
}