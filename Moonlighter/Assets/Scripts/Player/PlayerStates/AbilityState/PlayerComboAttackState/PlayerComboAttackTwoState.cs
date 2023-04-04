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

        AttackInputDelay(stateInfo);

        CheckAttackTime(stateInfo);

        CheckComboAttack();

        if (isAnimationEnded && false == comboAttack)
        {
            ChangeState(animator, PlayerStates.ComboAttackTwo, PlayerAnimParams.COMBOATTACKTWO, PlayerAnimParams.IDLE);
        }
        else if (isAnimationEnded && comboAttack)
        {
            inputHandler.UseComboInput();
            comboAttack = false;
            ChangeState(animator, PlayerStates.ComboAttackTwo, PlayerAnimParams.COMBOATTACKTWO, PlayerAnimParams.COMBOATTACKTHREE);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackInputDelayTime = 0;
    }
}
