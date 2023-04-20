using UnityEngine;
using EnumValue;

public class GolemSoldierState : StateMachineBehaviour
{
    protected Rigidbody2D rigid;
    protected Rigidbody2D target;
    protected Player player;
    protected GolemSoldier golemSoldier;
    protected float canAttackRange = 0.2f;
    protected float minDistance;
    protected float angleBetween;
    protected const float speedCorrectionValue = 0.25f;
    protected Vector2 moveVelocity;
    protected Vector2 dir = Vector2.down;
    protected Vector2 destination;
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigid = animator.gameObject.GetComponent<Rigidbody2D>();
        target = animator.gameObject.GetComponent<GolemSoldier>().Target.Rigid;
        player = target.gameObject.GetComponent<Player>();
        golemSoldier = animator.gameObject.GetComponent<GolemSoldier>();
    }

    protected void SetDirection(Animator animator)
    {
        angleBetween = Vector2.SignedAngle(Vector2.right, (target.position - rigid.position).normalized);

        if(-135f <= angleBetween && angleBetween < -45f)
        {
            dir = Vector2.down;
            golemSoldier.CurrentDir = GolemSoldierDirection.Down;
        }
        else if((-180f <= angleBetween && angleBetween < -135f)||(135f <= angleBetween && angleBetween < 180f))
        {
            dir = Vector2.left;
            golemSoldier.CurrentDir = GolemSoldierDirection.Left;
        }
        else if((0 <= angleBetween && angleBetween < 45f)||(-45f <= angleBetween && angleBetween < 0f))
        {
            dir = Vector2.right;
            golemSoldier.CurrentDir = GolemSoldierDirection.Right;
        }
        else if(45f <= angleBetween && angleBetween < 135f)
        {
            dir = Vector2.up;
            golemSoldier.CurrentDir = GolemSoldierDirection.Up;
        }
        animator.SetFloat(MonsterAnimParams.DIRX, dir.x);
        animator.SetFloat(MonsterAnimParams.DIRY, dir.y);
    }

    protected void SetDestination()
    {
        minDistance = 214700f;
        for (int i = 0; i < player.MonsterDestinationPos.Length; ++i)
        {
            float distance = Vector2.Distance(rigid.position, player.MonsterDestinationPos[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                destination = player.MonsterDestinationPos[i].position;
            }
        }
    }
}
