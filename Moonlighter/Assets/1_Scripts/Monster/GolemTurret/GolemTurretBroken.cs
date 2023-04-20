using UnityEngine;
using UnityEngine.Pool;

public class GolemTurretBroken : Monster
{
    private ObjectPool<GolemTurretProjectile> _projectilePool;

    [SerializeField]
    private GolemTurretProjectile _projectile;

    [SerializeField]
    private GameObject _target;

    private Animator _anim;

    public Transform[] FirePositions;

    public Vector2 Dir { get; private set; }

    public override void Awake()
    {
        base.Awake();
        _projectilePool = new ObjectPool<GolemTurretProjectile>(GenerateProjectile, SetActiveTrue);
        _anim = GetComponent<Animator>();
        _target = GameObject.Find(ObjectLiteral.PLAYER).gameObject;
    }

    private void Shoot()
    {
        GetProjectileFromPool();
    }

    GolemTurretProjectile GetProjectileFromPool() => _projectilePool.Get();

    GolemTurretProjectile GenerateProjectile()
    {
        GolemTurretProjectile projectile = Instantiate(_projectile);
        projectile.Pool = _projectilePool;
        return projectile;
    }

    private void SetActiveTrue(GolemTurretProjectile projectile) => projectile.gameObject.SetActive(true);

    private void SetDirection()
    {
        Dir = (_target.transform.position - transform.position).normalized;
        float angleBetween = Vector2.Angle(Vector2.right, Dir);
        if (Dir.y > 0)
        {
            if(0 < angleBetween && angleBetween <= 45f)
            {
                Dir = Vector2.right;
            }
            else if(135f < angleBetween && angleBetween <= 180f)
            {
                Dir = Vector2.left;
            }
            else if(45f < angleBetween && angleBetween <= 135f)
            {
                Dir = Vector2.up;
            }
        }
        else if (Dir.y < 0)
        {
            if (0 < angleBetween && angleBetween <= 45f)
            {
                Dir = Vector2.right;
            }
            else if (135f < angleBetween && angleBetween <= 180f)
            {
                Dir = Vector2.left;
            }
            else if (45f < angleBetween && angleBetween <= 135f)
            {
                Dir = Vector2.down;
            }
        }
        
        _anim.SetFloat(MonsterAnimParams.DIRX, Dir.x);
        _anim.SetFloat(MonsterAnimParams.DIRY, Dir.y);
    }
}
