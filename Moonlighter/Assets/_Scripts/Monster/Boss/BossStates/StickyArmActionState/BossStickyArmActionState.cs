using UnityEngine;

public class BossStickyArmActionState : BossState
{
    protected GameObject stickyArm;
    protected Animator stickyArmAnimator;


    protected float stickyArmLength = 5.0f;
    protected float speed;
    protected LineRenderer lineRenderer;
    protected float angle;

    protected Transform stickyArmPunchAxis;
    protected Transform stickyArmPunchOriginPos;

    protected float aimmingTime;
    protected float wieldingTime;

}
