using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public PlayerInputHandler InputHandler { get; private set; }

    public bool IsAnimationEnded { get; private set; }

    public bool IsChargeOn { get; private set; }

    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        if (InputHandler == null)
        {
            InputHandler = gameObject.GetComponentInParent<PlayerInputHandler>();
        }
    }

    public void AnimationTrigger()
    {
        IsAnimationEnded = false;
    }

    public void AnimationFinishTrigger()
    {
        IsAnimationEnded = true;
    }

    public void ResetAttackInput()
    {
        if (InputHandler.ComboInput)
        {
            InputHandler.UseComboInput();
        }
    }

    public void ResetWeaponAttackInput()
    {
        if (InputHandler.WeaponComboInput)
        {
            InputHandler.UseWeaponComboInput();
        }
    }

    public void ChargeTrigger()
    {
        IsChargeOn = true;
    }

    public void ResetChargeTrigger()
    {
        IsChargeOn = false;
    }
}
