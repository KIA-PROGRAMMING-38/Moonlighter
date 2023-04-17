using UnityEngine;

public class BossRocketArmBodyPunchUpState : BossRocketArmState
{
    Vector2 tmp;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tmp = animator.transform.position;
        tmp.y += 1.0f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.Lerp(animator.transform.position, tmp, 5f * Time.deltaTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
    }
}
