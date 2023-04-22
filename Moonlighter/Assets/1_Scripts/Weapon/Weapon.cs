using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumValue;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private BigSwordData _bigSwordData;

    public Animator Anim { get; private set; }
    public AnimationHandler AnimHandler { get; private set; }
    public GameObject[] AttackRange;

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

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        AnimHandler = GetComponent<AnimationHandler>();
        _bigSwordData.ComboAttackOneDamage = 20;
        _bigSwordData.ComboAttackTwoDamage = 30;
        _bigSwordData.ComboAttackThreeDamage = 60;
        _bigSwordData.SecondaryActionDamage = 60;
    }

    void Start()
    {
        Anim.SetBool(WeaponAnimParamsToHash.IDLE, true);
    }

    public int GetDamageValue()
    {
        return _bigSwordData.ComboAttackOneDamage;
    }

    private void ActiveSecondaryAction()
    {
        for (int i = 0; i < AttackRange.Length; ++i)
        {
            AttackRange[i].SetActive(true);
        }
    }

    private void InactiveSecondaryAction()
    {
        for (int i = 0; i < AttackRange.Length; ++i)
        {
            AttackRange[i].SetActive(false);
        }
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
        else if(_dirX != 0 && _dirY < 0)
        {
            _nowAttackDir = WeaponAttackDir.Down;
            AttackRange[(int)WeaponAttackDir.Down].SetActive(true);
        }
        else if(_dirX == 1 && _dirY == 0)
        {
            _nowAttackDir = WeaponAttackDir.Right;
            AttackRange[(int)WeaponAttackDir.Right].SetActive(true);
        }
        else if(_dirX == -1 && _dirY == 0)
        {
            _nowAttackDir = WeaponAttackDir.Left;
            AttackRange[(int)WeaponAttackDir.Left].SetActive(true);
        }
        else if(_dirX == 0 && _dirY == 1)
        {
            _nowAttackDir = WeaponAttackDir.Up;
            AttackRange[(int)WeaponAttackDir.Up].SetActive(true);
        }
        else if(_dirX == 0 && _dirY == -1)
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
