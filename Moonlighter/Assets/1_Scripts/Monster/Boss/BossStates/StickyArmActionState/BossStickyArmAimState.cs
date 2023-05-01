using UnityEngine;

public class BossStickyArmAimState : BossStickyArmActionState
{
    public GameObject StickyArm;
    public GameObject StickyArmPunch;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        StickyArm = animator.transform.GetChild(7).gameObject;
        StickyArmPunch = StickyArm.transform.GetChild(1).gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit2D pos = Physics2D.Raycast(StickyArm.transform.position, target.transform.position - StickyArm.transform.position, 100000f, 12);
        Debug.Log(pos.point);
        Debug.DrawRay(StickyArm.transform.position, target.transform.position - StickyArm.transform.position);
        Debug.Break();
        //StickyArmPunch.transform.position = Vector2.Lerp(StickyArmPunch.transform.position, poses[1].point, Time.deltaTime * 5f);

        aimmingTime += Time.deltaTime;

        if (aimmingTime >= 2.0f)
        {
            aimmingTime = 0;
            animator.SetTrigger(MonsterAnimParamsToHash.STICKYARMLAUNCHTRIGGER);
            stickyArmAnimator.SetTrigger(MonsterAnimParamsToHash.STICKYARMPUNCHTRIGGER);
        }
    }
}
