using EnumValue;
using UnityEngine;

public class PlayerComboAttackThreeState : PlayerAbilityState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player.CurrentState = PlayerStates.ComboAttackThree;
        SetMoveAttackDirection();
        rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        if (animHandler.IsAnimationEnded)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, PlayerStates.ComboAttackThree, PlayerAnimParams.COMBOATTACKTHREE, PlayerAnimParams.IDLE);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackInputDelayTime = 0;
    }
}
