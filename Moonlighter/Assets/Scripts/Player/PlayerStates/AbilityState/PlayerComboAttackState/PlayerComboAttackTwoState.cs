using EnumValue;
using UnityEngine;

public class PlayerComboAttackTwoState : PlayerAbilityState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.CurrentState = PlayerStates.ComboAttackTwo;
        rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        CheckAttackTime(stateInfo);

        if (isAnimationEnded)
        {
            ChangeState(animator, PlayerStates.ComboAttackTwo, PlayerAnimParams.COMBOATTACKTWO, PlayerAnimParams.IDLE);
        }
    }
}
