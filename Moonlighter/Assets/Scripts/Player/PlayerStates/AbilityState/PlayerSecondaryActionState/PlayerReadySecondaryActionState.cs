using EnumValue;
using UnityEngine;

public class PlayerReadySecondaryActionState : PlayerAbilityState
{
    private float _enoughChargeTime;
    private float _checkChargeTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        _enoughChargeTime = stateInfo.length * 0.95f;
        player.CurrentState = PlayerStates.ReadySecondaryAction;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        _checkChargeTime += Time.deltaTime;

        if (_checkChargeTime >= _enoughChargeTime)
        {
            if (inputHandler.SecondaryActionInput)
            {
                _checkChargeTime = 0;
                ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.ONSECONDARYACTION);
            }
        }

        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, PlayerStates.ReadySecondaryAction, PlayerAnimParams.READYSECONDARYACTION, PlayerAnimParams.IDLE);
        }
    }
}
