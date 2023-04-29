using UnityEngine;

public class TangleTraceState : TangleState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (false == tangle.IsHit)
        {
            rigid.velocity = (target.position - animator.transform.position).normalized * speed;
        }

        //if (false == tangle.IsCollision && false == tangle.IsDie)
        //{
        //    rigid.velocity = (target.position - animator.transform.position).normalized * speed;
        //}

    }
}
