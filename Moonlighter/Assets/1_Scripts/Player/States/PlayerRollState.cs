using DG.Tweening;
using UnityEngine;

public class PlayerRollState : PlayerState
{
    [SerializeField]
    private float _rollDirModifier = 0.5f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        DoRoll(stateInfo.length);
    }

    private void DoRoll(float duration)
    {
        Vector2 _rollDir = GetRollDirection(player, input);
        _rollDir *= _rollDirModifier;
        _rollDir *= player.Stat.RollSpeed;

        Vector2 destination = player.Rigid.position + _rollDir;

        player.Rigid.DOMove(destination, duration).SetEase(Ease.OutSine);

        static Vector2 GetRollDirection(PlayerCharacter playerCharacter, PlayerInputHandler playerInput)
        {
            if (playerInput.IsMoving)
            {
                float newX = playerCharacter.Anim.GetFloat(AnimParameters.MoveX);
                float newY = playerCharacter.Anim.GetFloat(AnimParameters.MoveY);
                return new Vector2(newX, newY).normalized;
            }
            else
            {
                return playerCharacter.PlayerFacingDirection.ToVec2().normalized;
            }
        }
    }
}