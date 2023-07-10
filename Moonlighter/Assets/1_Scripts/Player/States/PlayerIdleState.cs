using Enums;
using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    private PlayerCharacter _player;
    private PlayerInputHandler _input;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init(animator);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_input.MoveInput != Vector2.zero)
        {
            _player.Anim.SetBool(PlayerAnimParameters.Idle, false);
            _player.Anim.SetBool(PlayerAnimParameters.Move, true);
        }
        else if(_input.RollInput)
        {
            _player.Anim.SetBool(PlayerAnimParameters.Idle, false);
            _player.Anim.SetBool(PlayerAnimParameters.Roll, true);
        }
    }

    private void Init(Animator animator)
    {
        _player = animator.transform.root.GetComponent<PlayerCharacter>();
        _input = animator.transform.root.GetComponent<PlayerInputHandler>();
        _player.Rigid.velocity = Vector2.zero;
    }
}
