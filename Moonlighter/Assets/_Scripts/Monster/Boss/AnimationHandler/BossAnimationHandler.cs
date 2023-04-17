using UnityEngine;

public class BossAnimationHandler : MonoBehaviour
{
    public Animator Anim { get; private set; }

    public bool IsAnimationEnded { get; private set; }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public void ResetAnimationState()
    {
        IsAnimationEnded = false;
    }

    private void SetAnimationFinish()
    {
        IsAnimationEnded = true;
    }

}
