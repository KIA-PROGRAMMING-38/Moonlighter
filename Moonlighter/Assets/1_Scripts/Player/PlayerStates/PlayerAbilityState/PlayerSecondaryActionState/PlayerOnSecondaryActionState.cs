using EnumValue;
using UnityEngine;

public class PlayerOnSecondaryActionState : PlayerAbilityState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        player.CurrentState = PlayerStates.OnSecondaryAction;
        rigid.velocity = Vector2.zero;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LockRoll();

        LockAttack();

        switch (player.PrimaryWeapon)
        {
            case Weapons.ShortSwordAndShield:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, PlayerStates.OnSecondaryAction, PlayerAnimParamsToHash.ONSECONDARYACTION, PlayerAnimParamsToHash.IDLE);
                }
                if (inputHandler.MoveInput != Vector2.zero)
                {
                    ChangeState(animator, PlayerStates.OnSecondaryAction, PlayerAnimParamsToHash.ONSECONDARYACTION, PlayerAnimParamsToHash.SECONDARYACTION);
                }
                break;
            case Weapons.BigSword:
                if (false == inputHandler.SecondaryActionInput)
                {
                    ChangeState(animator, PlayerStates.OnSecondaryAction, PlayerAnimParamsToHash.ONSECONDARYACTION, PlayerAnimParamsToHash.SECONDARYACTION);
                }
                break;
        }
    }
}
