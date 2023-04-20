using EnumValue;
using UnityEngine;

public class PlayerComboAttackTwoState : PlayerAbilityState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SetMoveAttackDirection();
        player.CurrentState = PlayerStates.ComboAttackTwo;
        rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        if (animHandler.IsAnimationEnded && false == inputHandler.ComboInput)
        {
            ChangeState(animator, PlayerStates.ComboAttackTwo, PlayerAnimParamsToHash.COMBOATTACKTWO, PlayerAnimParamsToHash.IDLE);
        }
        else if (animHandler.IsAnimationEnded && inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, PlayerStates.ComboAttackTwo, PlayerAnimParamsToHash.COMBOATTACKTWO, PlayerAnimParamsToHash.COMBOATTACKTHREE);
        }
    }
}
