using DG.Tweening;
using UnityEngine;

public class MoveEffectState : StateMachineBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _moveEffectAlphaValue = 0.5f;
    private Vector3 _moveEffectScale = new Vector3(0.3f, 0.3f, 1);
    private Vector3 _moveEffectRotation = new Vector3(0, 0, -90);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
        DoFadeOut(_moveEffectAlphaValue, 0);
        animator.transform.localScale = _moveEffectScale;
        animator.transform.rotation = Quaternion.Euler(_moveEffectRotation);
    }

    private void DoFadeOut(float alpha, float duration) => _spriteRenderer.DOFade(alpha, duration);
}