using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : WeaponGroundedState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (inputHandler.MoveInput != Vector2.zero)
        {
            animator.SetFloat(WeaponAnimParams.DIRX, inputHandler.MoveInput.x);
            animator.SetFloat(WeaponAnimParams.DIRY, inputHandler.MoveInput.y);
        }

        if (inputHandler.ComboInput)
        {
            inputHandler.UseComboInput();
            ChangeState(animator, WeaponAnimParams.IDLE, WeaponAnimParams.COMBOATTACKONE);
        }
        
    }
}
