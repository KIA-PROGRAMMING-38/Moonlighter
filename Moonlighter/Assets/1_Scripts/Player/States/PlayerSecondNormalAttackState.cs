using UnityEngine;

public class PlayerSecondNormalAttackState : PlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        InitAttackState(stateInfo);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckAttackInput(stateInfo);

        if (IsStateEnd(stateInfo))
        {
            if (IsAttackInput())
            {
                ChangeNextState(PlayerAnimParameters.NormalAttack2, PlayerAnimParameters.NormalAttack3);
            }
            else
            {
                ChangeNextState(PlayerAnimParameters.NormalAttack2, PlayerAnimParameters.Idle);
            }
        }
    }
}