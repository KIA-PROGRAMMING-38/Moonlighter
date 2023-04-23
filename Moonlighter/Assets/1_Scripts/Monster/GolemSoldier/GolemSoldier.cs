using EnumValue;
using UnityEngine;

public class GolemSoldier : Monster
{
    public GameObject DetectRange;
    public Transform[] DamageRange;

    public GolemSoldierDirection CurrentDir { get; set; }

    public Player Target { get; private set; }

    private Animator _anim;

    public override void Awake()
    {
        base.Awake();
        Target = GameObject.Find(ObjectLiteral.PLAYER).GetComponent<Player>();
        _anim = GetComponent<Animator>();
        CurrentDir = GolemSoldierDirection.Down;
        monsterData.Maxhp = 100;
        monsterData.CurHp = monsterData.Maxhp;
        monsterData.NormalDamage = 15;
    }

    private void Start()
    {
        _anim.SetTrigger(MonsterAnimParams.AWAKE);
    }


    private void SetActiveDamageRange()
    {
        switch (CurrentDir)
        {
            case GolemSoldierDirection.Down:
                DamageRange[(int)GolemSoldierDirection.Down].gameObject.SetActive(true);
                DamageRange[(int)GolemSoldierDirection.Down].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                DamageRange[(int)GolemSoldierDirection.Down].gameObject.GetComponent<BoxCollider2D>().enabled = true;
                break;
            case GolemSoldierDirection.Left:
                DamageRange[(int)GolemSoldierDirection.Left].gameObject.SetActive(true);
                break;
            case GolemSoldierDirection.Right:
                DamageRange[(int)GolemSoldierDirection.Right].gameObject.SetActive(true);
                break;
            case GolemSoldierDirection.Up:
                DamageRange[(int)GolemSoldierDirection.Up].gameObject.SetActive(true);
                break;
        }
    }

    private void InactiveDamageRange()
    {
        switch (CurrentDir)
        {
            case GolemSoldierDirection.Down:
                DamageRange[(int)GolemSoldierDirection.Down].gameObject.SetActive(false);
                break;
            case GolemSoldierDirection.Left:
                DamageRange[(int)GolemSoldierDirection.Left].gameObject.SetActive(false);
                break;
            case GolemSoldierDirection.Right:
                DamageRange[(int)GolemSoldierDirection.Right].gameObject.SetActive(false);
                break;
            case GolemSoldierDirection.Up:
                DamageRange[(int)GolemSoldierDirection.Up].gameObject.SetActive(false);
                break;
        }
    }
}