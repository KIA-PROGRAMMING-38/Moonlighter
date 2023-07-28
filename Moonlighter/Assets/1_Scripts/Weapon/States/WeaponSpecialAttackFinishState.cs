using UnityEngine;

public class WeaponSpecialAttackFinishState : WeaponState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentWeapon.PerformWhileSpecialAttackFinish();
    }
}