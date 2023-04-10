using UnityEngine;
using UnityEngine.Pool;
using EnumValue;

public class GolemTurretProjectile : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator _anim;
    private GolemTurretBroken _base;

    private readonly Vector3 _turnDownDirection = new Vector3(0, 0, 0);
    private readonly Vector3 _turnLeftDirection = new Vector3(0, 0, -90);
    private readonly Vector3 _turnRightDirection = new Vector3(0, 0, 90);
    private readonly Vector3 _turnUpDirection = new Vector3(0, 0, 180);


    public ObjectPool<GolemTurretProjectile> Pool { private get; set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _base = GameObject.Find(ObjectLiteral.GOLEMTURRET).GetComponentInParent<GolemTurretBroken>();
        transform.SetParent(_base.transform);
    }

    private void OnEnable()
    {
        SetFireDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagLiteral.FINISH) || collision.CompareTag(TagLiteral.PLAYER))
        {
            rigid.velocity = Vector2.zero;
            _anim.SetTrigger(MonsterAnimParams.ISCOLLISION);
        }
    }

    void ProjectileToPool()
    {
        Pool.Release(this);
        gameObject.SetActive(false);
    }

    void SetFireDirection()
    {
        if (_base.Dir == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(_turnDownDirection);
            rigid.velocity = Vector2.down;
            transform.position = _base.FirePositions[(int)GolemTurretFirePositions.Down].position;
        }
        else if (_base.Dir == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(_turnLeftDirection);
            rigid.velocity = Vector2.left;
            transform.position = _base.FirePositions[(int)GolemTurretFirePositions.Left].position;
        }
        else if (_base.Dir == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(_turnRightDirection);
            rigid.velocity = Vector2.right;
            transform.position = _base.FirePositions[(int)GolemTurretFirePositions.Right].position;
        }
        else if (_base.Dir == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(_turnUpDirection);
            rigid.velocity = Vector2.up;
            transform.position = _base.FirePositions[(int)GolemTurretFirePositions.Up].position;
        }
    }
}
