using EnumValue;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerReadySecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enoughChargeTime = stateInfo.length;
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
            if (inputHandler.SecondaryActionInput)
            {
                animHandler.ResetChargeTrigger();
                ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.ONSECONDARYACTION);
            }
        }

        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.IDLE);
        }

    }
}
