using EnumValue;
using UnityEngine;

public class PlayerReadySecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rigid.velocity = Vector2.zero;
        player.CurrentState = PlayerStates.ReadySecondaryAction;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        LockAttack();

        if (animHandler.IsChargeOn)
        {
            animHandler.ResetChargeTrigger();
            if (inputHandler.SecondaryActionInput)
            {
                ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParamsToHash.READYSECONDARYACTION, PlayerAnimParamsToHash.ONSECONDARYACTION);
            }
        }

        if (false == inputHandler.SecondaryActionInput)
        {
            animHandler.ResetChargeTrigger();
            ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParamsToHash.READYSECONDARYACTION, PlayerAnimParamsToHash.IDLE);
        }
    }
}
