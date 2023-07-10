using DG.Tweening;
using UnityEngine;

public class RollEffectState : StateMachineBehaviour
{
    private const int _rollEffectCount = 4;

    private int[] AnimationClipHash =
    {
        AnimationNameToHash.RollEffect1, 
        AnimationNameToHash.RollEffect2,
        AnimationNameToHash.RollEffect3,
        AnimationNameToHash.RollEffect4
    };

    private SpriteRenderer _spriteRenderer;

    private Vector3 _endRotationValue = new Vector3(0, 0, 180);
    private float _endAlphaValue = 0;
    private float _rollEffectDuration = 0.6f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();

        int rollEffectIndex = Random.Range(0, _rollEffectCount);
        animator.Play(AnimationClipHash[rollEffectIndex]);

        DoFadeOut(_endAlphaValue, _rollEffectDuration);

        DoRatateEffect(animator, _endRotationValue, _rollEffectDuration);
    }

    private void DoRatateEffect(Animator animator, Vector3 endRotationValue, float duration)
    {
        animator.transform.DOLocalRotate(endRotationValue, duration);
    }

    private void DoFadeOut(float alpha, float duration)
    {
        _spriteRenderer.DOFade(alpha, duration);
    }
}