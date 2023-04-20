using UnityEngine;

public class BossRocketArmBodyPunchUpState : BossRocketArmState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        punchUpPoint = animator.transform.position;
        punchUpPoint.y += 3.0f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.Lerp(animator.transform.position, punchUpPoint, 5f * Time.deltaTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
    }
}
