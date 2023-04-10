using EnumValue;
using UnityEngine;

public class PlayerComboAttackOneState : PlayerAbilityState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.CurrentState = PlayerStates.ComboAttackOne;
        rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        if (animHandler.IsAnimationEnded && false == inputHandler.ComboInput)
        {
            ChangeState(animator, PlayerStates.ComboAttackOne, PlayerAnimParams.COMBOATTACKONE, PlayerAnimParams.IDLE);
        }

        if (animHandler.IsAnimationEnded && inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, PlayerStates.ComboAttackOne, PlayerAnimParams.COMBOATTACKONE, PlayerAnimParams.COMBOATTACKTWO);
        }
    }
}
