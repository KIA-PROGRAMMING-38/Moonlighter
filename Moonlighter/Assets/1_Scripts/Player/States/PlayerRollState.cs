using DG.Tweening;
using Enums;
using UnityEngine;

public class PlayerRollState : StateMachineBehaviour
{
    private PlayerCharacter _player;
    private PlayerInputHandler _input;

    private Vector3 _rollDir;
    private Vector3[] _directions =
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right
    };

    private float _defaultRollSpeed;
    private float _rollDirModifier = 0.5f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init(animator);
        SetRollVelocity(stateInfo);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1)
        {
            if(_input.MoveInput != Vector2.zero)
            {
                _player.Anim.SetBool(PlayerAnimParameters.Roll, false);
                _player.Anim.SetBool(PlayerAnimParameters.Move, true);
            }
            else if(_input.MoveInput == Vector2.zero)
            {
                _player.Anim.SetBool(PlayerAnimParameters.Roll, false);
                _player.Anim.SetBool(PlayerAnimParameters.Idle, true);
            }
        }
    }

    private void Init(Animator animator)
    {
        _player = animator.transform.root.GetComponent<PlayerCharacter>();
        _input = animator.transform.root.GetComponent<PlayerInputHandler>();

        _defaultRollSpeed = _player.Stat.RollSpeed;

        if (_input.MoveInput == Vector2.zero)
        {
            _rollDir = _directions[(int)_player.PlayerFacingDirection] * _rollDirModifier;
        }
        else
        {
            _rollDir.Set(_player.Anim.GetFloat(PlayerAnimParameters.MoveX), _player.Anim.GetFloat(PlayerAnimParameters.MoveY), 0);
            _rollDir.Normalize();
            _rollDir *= _rollDirModifier;
        }
    }

    private void SetRollVelocity(AnimatorStateInfo stateInfo)
    {
        _player.Rigid.DOMove((Vector2)(_player.transform.position + _rollDir * _defaultRollSpeed), stateInfo.length).SetEase(Ease.OutSine);
    }
}