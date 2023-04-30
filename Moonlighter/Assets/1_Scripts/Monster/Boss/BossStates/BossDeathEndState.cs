using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathEndState : BossState
{
    public GameObject VirtualCam;
    private float _elapsedTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        VirtualCam = GameObject.Find("CM vcam1").gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime += Time.deltaTime;
        if(Mathf.Abs(_elapsedTime - stateInfo.length) < 0.05f)
        {
            _elapsedTime = 0;
            VirtualCam.GetComponent<FollowCam>().enabled = true;
        }
    }

}
