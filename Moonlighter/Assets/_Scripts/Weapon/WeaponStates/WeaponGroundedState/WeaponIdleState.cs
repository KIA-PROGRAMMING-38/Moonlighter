using EnumValue;
using UnityEngine;

public class WeaponIdleState : WeaponGroundedState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.CurrentState != PlayerStates.Roll && inputHandler.MoveInput != Vector2.zero)
        {
            SetDirection(animator);
        }

        if (player.CurrentState == PlayerStates.ComboAttackOne)
        {
            ChangeState(animator, WeaponAnimParams.IDLE, WeaponAnimParams.COMBOATTACKONE);
        }
        
    }

    private void SetDirection(Animator animator)
    {
        animator.SetFloat(WeaponAnimParams.DIRX, inputHandler.MoveInput.x);
        animator.SetFloat(WeaponAnimParams.DIRY, inputHandler.MoveInput.y);
    }
}
