using Enums;
using UnityEngine;

public class ShortSword : Weapon
{
    private float _shieldedMovementSpeed = 0.5f;

    public override void Init(WeaponId weaponId)
    {
        data = Managers.Data.WeaponDataTable[(int)weaponId];
    }

    public override void PerformNormalAttack()
    {
        Debug.Log("NormalAttack");
    }

    public override void PerformMoveInputOnSpecialAttack(PlayerInputHandler input)
    {
        SetShieldedMovement(input);
    }

    public override void PerformWhileSpecialAttackFinish() { }

    private void SetShieldedMovement(PlayerInputHandler input)
    {
        Vector2 moveInput = input.MoveInput;

        player.Rigid.velocity = moveInput * _shieldedMovementSpeed;
    }
}