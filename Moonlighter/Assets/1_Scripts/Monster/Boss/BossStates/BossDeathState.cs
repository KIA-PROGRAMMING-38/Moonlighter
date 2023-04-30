using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossState
{
    public GameObject BossRocketArm;
    public GameObject VirtualCam;
    private float _elapsedTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        boss.GetComponent<BoxCollider2D>().enabled = false;
        BossRocketArm = animator.transform.GetChild(6).gameObject;
        BossRocketArm.SetActive(false);
        VirtualCam = GameObject.Find("CM vcam1").gameObject;
        VirtualCam.GetComponent<FollowCam>().enabled = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime += Time.deltaTime;
        Vector3 tmp = VirtualCam.transform.position;
        tmp = Vector3.Lerp(tmp, animator.transform.position + Vector3.up * 0.5f, _elapsedTime / 1.5f);
        tmp.z = -10f;
        VirtualCam.transform.position = tmp;
        if(_elapsedTime >= 1.5f)
        {
            _elapsedTime = 0;
        }
    }
}
