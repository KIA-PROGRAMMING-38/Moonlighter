using EnumValue;
using UnityEngine;

public class PlayerComboAttackOneState : PlayerAbilityState
{
    private float _checkAttackTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rigid.velocity = Vector2.zero;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        CheckAttackTime(stateInfo);

        if (isAnimationEnded)
        {
            ChangeState(animator, PlayerStates.ComboAttackOne, PlayerAnimParams.COMBOATTACKONE, PlayerAnimParams.IDLE);
        }
    }

    #region ComboAttackOne State Functions

    private void CheckAttackTime(AnimatorStateInfo stateInfo )
    {
        _checkAttackTime += Time.deltaTime;

        if (_checkAttackTime >= stateInfo.length * 0.95f)
        {
            _checkAttackTime = 0;
            isAnimationEnded = true;
        }
    }

    #endregion
}
