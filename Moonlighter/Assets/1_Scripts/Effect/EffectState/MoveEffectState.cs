using UnityEngine;

public class MoveEffectState : EffectState
{
    [SerializeField]
    private float _moveEffectAlphaValue = 0.5f;
    [SerializeField]
    private Vector3 _moveEffectScale = new Vector3(0.3f, 0.3f, 1);
    [SerializeField]
    private Vector3 _moveEffectRotation = new Vector3(0, 0, -90);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        effectController.FadeOut(_moveEffectAlphaValue, 0);
        animator.transform.localScale = _moveEffectScale;
        animator.transform.rotation = Quaternion.Euler(_moveEffectRotation);
    }
}