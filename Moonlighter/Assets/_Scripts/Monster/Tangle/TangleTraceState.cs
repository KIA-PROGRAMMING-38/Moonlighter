using UnityEngine;

public class TangleTraceState : TangleState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (tangle.IsCollision)
        {
            rigid.velocity = Vector2.zero;
        }
        else
        {
            rigid.velocity = (target.position - animator.transform.position).normalized * speed;
        }

    }
}
