using UnityEngine;

public class TangleState : StateMachineBehaviour
{
    protected Rigidbody2D rigid;
    protected Transform target;
    protected Tangle tangle;

    protected float distance;
    protected float speed = 0.3f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tangle = animator.gameObject.GetComponent<Tangle>();
        rigid = animator.gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.Find(ObjectLiteral.PLAYER).transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector3.Distance(animator.transform.position, target.position);
    }
}
