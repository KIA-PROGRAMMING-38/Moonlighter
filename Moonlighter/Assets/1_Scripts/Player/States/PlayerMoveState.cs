using Enums;
using UnityEngine;

public class PlayerMoveState : StateMachineBehaviour
{
    private PlayerCharacter _player;
    private PlayerInputHandler _input;
    private float _defaultMoveSpeed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init(animator);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player.SetFacingDirection();
        if(_input.MoveInput == Vector2.zero)
        {
            _player.PrevState = PlayerState.Move;
            _player.Anim.SetBool(PlayerAnimParameters.Move, false);
            _player.Anim.SetBool(PlayerAnimParameters.Idle, true);
        }
        else if (_input.RollInput)
        {
            _player.PrevState = PlayerState.Move;
            _player.Anim.SetBool(PlayerAnimParameters.Move, false);
            _player.Anim.SetBool(PlayerAnimParameters.Roll, true);
        }
        else
        {
            _player.PrevState = PlayerState.Move;
            _player.Anim.SetFloat(PlayerAnimParameters.MoveX, _input.MoveInput.x);
            _player.Anim.SetFloat(PlayerAnimParameters.MoveY, _input.MoveInput.y);
            _player.Rigid.velocity = _input.MoveInput * _defaultMoveSpeed;
        }
    }

    private void Init(Animator animator)
    {
        _player = animator.transform.root.GetComponent<PlayerCharacter>();
        _input = animator.transform.root.GetComponent<PlayerInputHandler>();
        _defaultMoveSpeed = Managers.Data.CharacterStatDataTable[(int)CharacterStatId.Player].MoveSpeed;
    }
}