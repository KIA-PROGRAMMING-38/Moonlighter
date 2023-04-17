using UnityEngine;

public class BossRocketArmBodyPunchState : BossRocketArmState
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position =  Vector2.Lerp(animator.transform.position, RocketArmShadow.AttackPoint.position + new Vector3(0, 0.2f, 0), 5f * Time.deltaTime);
    }
}
