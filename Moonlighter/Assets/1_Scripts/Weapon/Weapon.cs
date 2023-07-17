using Enums;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected PlayerCharacter player;

    public Animator Anim { get; private set; }

    protected WeaponData data;

    public virtual void Awake()
    {
        player = transform.root.GetComponent<PlayerCharacter>();
        Anim = GetComponent<Animator>();
    }

    public virtual void Init(WeaponId weaponId) { }

    public abstract void NormalAttack();
    public abstract void PerformMoveInputWhileChargeEnd(PlayerInputHandler input);
    public abstract void PerformMoveInputWhileCharging(PlayerInputHandler input);
    public abstract void PerformWhileSpecialAttackFinish();
}