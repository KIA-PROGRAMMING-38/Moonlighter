using UnityEngine;
using EnumValue;

public class PlayerRollState : PlayerAbilityState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentState = PlayerStates.Roll;

        SetRollDirection(animator);

        rigid.velocity = rollDir * playerData.RollingVelocity;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        LockRoll();

        LockAttack();
        
        if (animHandler.IsAnimationEnded)
        {
            ChangeState(animator, PlayerStates.Roll, PlayerAnimParams.ROLL, PlayerAnimParams.IDLE);
        }
    }
}
