using DG.Tweening;
using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerCharacter player;
    protected PlayerInputHandler input;
    protected Vector2 zeroVelocity = Vector2.zero;

    private bool _isAttackInput;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.root.GetComponent<PlayerCharacter>();
        input = animator.transform.root.GetComponent<PlayerInputHandler>();
    }

    protected bool IsStateEnd(AnimatorStateInfo stateInfo) => stateInfo.normalizedTime >= 1;

    protected void InitAttackState(AnimatorStateInfo stateInfo)
    {
        player.Rigid.velocity = zeroVelocity;
        _isAttackInput = false;
        if (input.IsMoving)
        {
            player.Anim.SetFloat(PlayerAnimParameters.MoveX, input.MoveInput.x);
            player.Anim.SetFloat(PlayerAnimParameters.MoveY, input.MoveInput.y);

            player.SetFacingDirection();
            Vector2 rushDistance = player.PlayerFacingDirection.ToVec2() * 0.1f;
            player.Rigid.DOMove(player.Rigid.position + rushDistance, stateInfo.length * 0.2f);
        }
    }

    protected void CheckAttackInput(AnimatorStateInfo stateInfo)
    {
        if(false == _isAttackInput && stateInfo.normalizedTime >= 0.3f)
        {
            if (input.NormalAttackInput)
            {
                _isAttackInput = true;
            }
        }
    }

    protected bool IsAttackInput() => _isAttackInput;

    protected void ExitCurrentState(int currentState)
    {
        player.Anim.SetBool(currentState, false);
    }

    protected void EnterNextState(int nextState)
    {
        player.Anim.SetBool(nextState, true);
    }

    protected void ChangeNextState(int current, int next)
    {
        ExitCurrentState(current);
        EnterNextState(next);
    }
}