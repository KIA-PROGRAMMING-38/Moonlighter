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

        if (player.CurrentState != PlayerStates.Roll && inputHandler.WeaponComboInput)
        {
            inputHandler.UseWeaponComboInput();
            ChangeState(animator, WeaponAnimParamsToHash.IDLE, WeaponAnimParamsToHash.COMBOATTACKONE);
        }
        else if (player.CurrentState != PlayerStates.Roll && inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, WeaponAnimParamsToHash.IDLE, WeaponAnimParamsToHash.READYSECONDARYACTION);
        }
        
    }
}
