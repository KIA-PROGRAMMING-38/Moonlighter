using UnityEngine;

public class WeaponReadySecondaryActionState : WeaponAbilityState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (false == inputHandler.SecondaryActionInput)
        {
            ChangeState(animator, WeaponAnimParamsToHash.READYSECONDARYACTION, WeaponAnimParamsToHash.IDLE);
        }

        if (animHandler.IsChargeOn)
        {
            if (inputHandler.SecondaryActionInput)
            {
                animHandler.ResetChargeTrigger();
                ChangeState(animator, WeaponAnimParamsToHash.READYSECONDARYACTION, WeaponAnimParamsToHash.ONSECONDARYACTION);
            }
        }
    }
}
