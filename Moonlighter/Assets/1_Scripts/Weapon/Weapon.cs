using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumValue;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private BigSwordData _bigSwordData;

    [SerializeField]
    private ShortSwordAndShieldData _shortSwordAndShield;

    private Player _player;

    public Animator Anim { get; private set; }
    public AnimationHandler AnimHandler { get; private set; }
    public GameObject[] AttackRange;
    public GameObject BigSwordSecondaryAction;

    private WeaponAttackDir _nowAttackDir;
    private float _dirX;
    private float _dirY;

    public BigSwordData BigSwordData
    {
        get
        {
            return _bigSwordData;
        }
    }

    public ShortSwordAndShieldData ShortSwordAndShieldData
    {
        get
        {
            return _shortSwordAndShield;
        }
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        AnimHandler = GetComponent<AnimationHandler>();
        _player = transform.root.GetComponent<Player>();
        Anim.runtimeAnimatorController = BigSwordData.WeaponController;

        WeaponPresenter.OnChangeWeapon -= ChangePrimaryWeapon;
        WeaponPresenter.OnChangeWeapon += ChangePrimaryWeapon;
    }

    void Start()
    {
        Anim.SetBool(WeaponAnimParamsToHash.IDLE, true);
    }

    private void ChangePrimaryWeapon()
    {
        Weapons tmp = _player.PrimaryWeapon;
        _player.PrimaryWeapon = _player.SecondaryWeapon;
        _player.SecondaryWeapon = tmp;
        switch (_player.PrimaryWeapon)
        {
            case Weapons.BigSword:
                Anim.runtimeAnimatorController = _bigSwordData.WeaponController;
                _player.Anim.runtimeAnimatorController = _bigSwordData.PlayerController;
                Anim.SetBool(WeaponAnimParamsToHash.IDLE, true);
                _player.Anim.SetBool(PlayerAnimParamsToHash.IDLE, true);
                break;
            case Weapons.ShortSwordAndShield:
                Anim.runtimeAnimatorController = _shortSwordAndShield.WeaponController;
                _player.Anim.runtimeAnimatorController = _shortSwordAndShield.PlayerController;
                Anim.SetBool(WeaponAnimParamsToHash.IDLE, true);
                _player.Anim.SetBool(PlayerAnimParamsToHash.IDLE, true);
                break;
        }

    }

    public int GetDamageValue()
    {
        return _bigSwordData.ComboAttackOneDamage;
    }

    private void ActiveSecondaryAction()
    {
        BigSwordSecondaryAction.SetActive(true);
    }

    private void InactiveSecondaryAction()
    {
        BigSwordSecondaryAction.SetActive(false);
    }

    private void ActiveAttack()
    {
        _dirX = Anim.GetFloat(WeaponAnimParamsToHash.DIRX);
        _dirY = Anim.GetFloat(WeaponAnimParamsToHash.DIRY);

        if (_dirX != 0 && _dirY > 0)
        {
            _nowAttackDir = WeaponAttackDir.Up;
            AttackRange[(int)WeaponAttackDir.Up].SetActive(true);
        }
        else if (_dirX != 0 && _dirY < 0)
        {
            _nowAttackDir = WeaponAttackDir.Down;
            AttackRange[(int)WeaponAttackDir.Down].SetActive(true);
        }
        else if (_dirX == 1 && _dirY == 0)
        {
            _nowAttackDir = WeaponAttackDir.Right;
            AttackRange[(int)WeaponAttackDir.Right].SetActive(true);
        }
        else if (_dirX == -1 && _dirY == 0)
        {
            _nowAttackDir = WeaponAttackDir.Left;
            AttackRange[(int)WeaponAttackDir.Left].SetActive(true);
        }
        else if (_dirX == 0 && _dirY == 1)
        {
            _nowAttackDir = WeaponAttackDir.Up;
            AttackRange[(int)WeaponAttackDir.Up].SetActive(true);
        }
        else if (_dirX == 0 && _dirY == -1)
        {
            _nowAttackDir = WeaponAttackDir.Down;
            AttackRange[(int)WeaponAttackDir.Down].SetActive(true);
        }
    }

    private void InactiveAttack()
    {
        AttackRange[(int)_nowAttackDir].SetActive(false);
    }
}
