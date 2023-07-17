using UnityEngine;

public class PlayerIdleState : PlayerState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.Move);
    }

    protected override void OnRoll(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.Roll);
    }

    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeNextState(PlayerAnimParameters.NormalAttack);
    }
}
