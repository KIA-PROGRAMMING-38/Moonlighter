using UnityEngine;

public class AnimEventHandler : MonoBehaviour
{
    public bool IsAnimationFinsih { get; private set; }

    public void AnimationStart()
    {
        IsAnimationFinsih = false;
    }

    private void AnimationFinishTrigger() => IsAnimationFinsih = true;
}