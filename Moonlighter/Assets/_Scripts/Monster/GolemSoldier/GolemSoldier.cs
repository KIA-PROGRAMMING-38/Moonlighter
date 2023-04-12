using EnumValue;
using UnityEngine;

public class GolemSoldier : MonoBehaviour
{
    public GameObject DetectRange;
    public Transform[] DamageRange;

    public GolemSoldierDirection CurrentDir { get; set; }

    public Player Target { get; private set; }

    private Animator _anim;

    private void Awake()
    {
        Target = GameObject.Find(ObjectLiteral.PLAYER).GetComponent<Player>();
        _anim = GetComponent<Animator>();
        CurrentDir = GolemSoldierDirection.Down;
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

    private void InActiveDamageRange()
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