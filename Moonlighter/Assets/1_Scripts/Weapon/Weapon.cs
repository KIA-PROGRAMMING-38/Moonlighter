using Enums;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public PlayerCharacter Player { get; private set; }

    protected WeaponData data;

    public virtual void Awake()
    {
        Player = transform.root.GetComponent<PlayerCharacter>();
    }

    public virtual void Init(WeaponId weaponId) { }

    public abstract void NormalAttack();
    
}