using Enums;
using UnityEngine;

public class ShortSword : Weapon
{
    private float _shieldedMovementSpeed = 0.5f;

    public override void Init(WeaponId weaponId)
    {
        data = Managers.Data.WeaponDataTable[(int)weaponId];
    }

    public override void NormalAttack()
    {
        Debug.Log("NormalAttack");
    }

    public override void PerformMoveInputWhileCharging(PlayerInputHandler input)
    {
        Vector2 moveInput = input.MoveInput;

        player.Rigid.velocity = moveInput * _shieldedMovementSpeed;
    }

    public override void PerformMoveInputWhileChargeEnd(PlayerInputHandler input)
    {
        Vector2 moveInput = input.MoveInput;

        Vector2 animParams = player.PlayerFacingDirection.ToVec2();

        player.Anim.SetFloat(PlayerAnimParameters.MoveX, animParams.x);
        player.Anim.SetFloat(PlayerAnimParameters.MoveY, animParams.y);

        player.Rigid.velocity = moveInput * _shieldedMovementSpeed;
    }

    public override void PerformWhileSpecialAttackFinish() { }
}