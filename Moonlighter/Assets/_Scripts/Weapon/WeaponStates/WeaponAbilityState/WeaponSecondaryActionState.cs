using EnumValue;
using UnityEngine;

public class WeaponSecondaryActionState : WeaponAbilityState
{
    float _checkTime;
    bool isEnd = false;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _checkTime += Time.deltaTime;
        if (_checkTime >= stateInfo.length * 0.95f)
        {
            isEnd = true;
        }

        if (isEnd)
        {
            isEnd = false;
            ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.IDLE);
        }

        //if (player.CurrentState == PlayerStates.Idle)
        //{
        //    ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.IDLE);
        //}

        //if (player.CurrentState == PlayerStates.OnSecondaryAction)
        //{
        //    ChangeState(animator, WeaponAnimParams.SECONDARYACTION, WeaponAnimParams.ONSECONDARYACTION);
        //}
    }
}
