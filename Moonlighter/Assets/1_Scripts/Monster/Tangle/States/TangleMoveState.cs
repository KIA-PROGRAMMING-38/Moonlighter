using UnityEngine;

public class TangleMoveState : MonsterState
{
    protected override void OnMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveToPlayer();   
    }

    [SerializeField][Range(0.1f, 5f)] private float _zigzagSpeed = 3f;
    private void MoveToPlayer()
    {
        Vector2 directionToPlayer = (target.position - monster.Rigid.position).normalized;
        Vector2 perpendicular = Vector2.Perpendicular(directionToPlayer);

        float zigzagModifier = Mathf.Sin(Time.time * _zigzagSpeed);

        Vector2 finalDirection = directionToPlayer + perpendicular * zigzagModifier;

        Vector2 velocity = finalDirection.normalized * monster.Stat.MoveSpeed;

        monster.Rigid.velocity = velocity;
    }
}