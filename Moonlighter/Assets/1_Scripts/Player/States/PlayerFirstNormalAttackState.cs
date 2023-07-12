using UnityEngine;

public class PlayerFirstNormalAttackState : PlayerState
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
                ChangeNextState(PlayerAnimParameters.NormalAttack1, PlayerAnimParameters.NormalAttack2);
            }
            else
            {
                ChangeNextState(PlayerAnimParameters.NormalAttack1, PlayerAnimParameters.Idle);
            }
        }
    }
}