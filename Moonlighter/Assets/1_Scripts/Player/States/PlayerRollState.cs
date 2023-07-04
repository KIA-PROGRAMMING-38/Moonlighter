using UnityEngine;
using Enums;

public class PlayerRollState : StateMachineBehaviour
{
    private PlayerCharacter _player;
    private PlayerInputHandler _input;
    private AnimEventHandler _animEventHandler;
    private Vector2 _rollDir;
    private float _rollVelocityMultiplier;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init(animator);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetRollVelocity(stateInfo);

        if (_animEventHandler.IsAnimationFinsih)
        {
            if(_input.MoveInput != Vector2.zero)
            {
                _player.PrevState = PlayerState.Roll;
                _player.Anim.SetBool(PlayerAnimParameters.Roll, false);
                _player.Anim.SetBool(PlayerAnimParameters.Move, true);
            }
            else if(_input.MoveInput == Vector2.zero)
            {
                _player.PrevState = PlayerState.Roll;
                _player.Anim.SetBool(PlayerAnimParameters.Roll, false);
                _player.Anim.SetBool(PlayerAnimParameters.Idle, true);
            }
        }
    }

    private void Init(Animator animator)
    {
        _player = animator.transform.root.GetComponent<PlayerCharacter>();
        _input = animator.transform.root.GetComponent<PlayerInputHandler>();
        _animEventHandler = animator.transform.GetComponent<AnimEventHandler>();
        _rollVelocityMultiplier = 1;
        SetRollDir();
        _animEventHandler.AnimationStart();
    }

    private void SetRollDir()
    {
        if(_player.PrevState == PlayerState.Idle)
        {
            int dirX = Mathf.RoundToInt(_player.Anim.GetFloat(PlayerAnimParameters.MoveX));
            int dirY = Mathf.RoundToInt(_player.Anim.GetFloat(PlayerAnimParameters.MoveY));
            if(dirY > 0)
            {
                _rollDir = Vector2.up;
            }
            else if(dirY < 0)
            {
                _rollDir = Vector2.down;
            }
            else
            {
                _rollDir.Set(dirX, dirY);
            }
        }
        else
        {
            _rollDir.Set(_player.Anim.GetFloat(PlayerAnimParameters.MoveX), _player.Anim.GetFloat(PlayerAnimParameters.MoveY));
        }
    }

    private void SetRollVelocity(AnimatorStateInfo stateInfo)
    {
        _rollVelocityMultiplier = EaseFunc.EaseOutCubic(_rollVelocityMultiplier, _player.Stat.RollSpeed, Time.deltaTime / stateInfo.normalizedTime);
        _player.Rigid.velocity = _rollDir * _rollVelocityMultiplier;
    }
}