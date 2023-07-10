using DG.Tweening;
using UnityEngine;

public class RollEffectState : EffectState
{
    [SerializeField]
    private int[] AnimationClipHash =
    {
        AnimationNameToHash.RollEffect1, 
        AnimationNameToHash.RollEffect2,
        AnimationNameToHash.RollEffect3,
        AnimationNameToHash.RollEffect4
    };

    [SerializeField]
    private Vector3 _endRotationValue = new Vector3(0, 0, 180);
    [SerializeField]
    private float _endAlphaValue = 0;
    [SerializeField]
    private float _rollEffectDuration = 0.6f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.Play(AnimationClipHash.GetRandomValue());

        effectController.FadeOut(_endAlphaValue, _rollEffectDuration);
        effectController.RotateEffect(_endRotationValue, _rollEffectDuration, RotateMode.Fast);
    }
}