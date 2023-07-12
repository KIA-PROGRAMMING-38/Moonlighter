using UnityEngine;

public class PlayerThirdNormalAttackState : PlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        InitAttackState(stateInfo);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (IsStateEnd(stateInfo))
        {
            ChangeNextState(PlayerAnimParameters.NormalAttack3, PlayerAnimParameters.Idle);
        }
    }
}