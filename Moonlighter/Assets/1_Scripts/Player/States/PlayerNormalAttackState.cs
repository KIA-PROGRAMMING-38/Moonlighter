using DG.Tweening;
using Enums;
using System;
using UnityEngine;

public class PlayerNormalAttackState : PlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        CheckRushAttack(stateInfo);
    }

    [SerializeField][Range(0, 0.5f)] private float _attackableMinTime = 0.3f;
    [SerializeField][Range(0.5f, 1f)] private float _attackableMaxTime = 0.7f;
    protected override void OnNormalAttack(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < _attackableMinTime)
        {
            return;
        }

        if(stateInfo.normalizedTime > _attackableMaxTime)
        {
            return;
        }

        ChangeNextState(PlayerAnimParameters.NormalAttack);
    }

    [SerializeField][Range(0.1f, 0.3f)] private float _rushDistanceModifier = 0.15f;
    [SerializeField][Range(0, 0.2f)] private float _rushTime = 0.1f;
    private void CheckRushAttack(AnimatorStateInfo stateInfo)
    {
        if (input.IsMoving)
        {
            player.Anim.SetFloat(PlayerAnimParameters.MoveX, input.MoveInput.x);
            player.Anim.SetFloat(PlayerAnimParameters.MoveY, input.MoveInput.y);

            player.SetFacingDirection();

            Vector2 rushDistance = player.PlayerFacingDirection.ToVec2() * _rushDistanceModifier;
            player.Rigid.DOMove(player.Rigid.position + rushDistance, stateInfo.length * _rushTime);

            Transform moveEffectTransform = player.transform.Find("Body").Find("MoveEffectPosition");
            Vector3 moveEffectSpawnPosition = GetEffectPosition(player.PlayerFacingDirection, moveEffectTransform);
            Managers.Effect.PlayEffect(EffectId.MoveEffect, moveEffectSpawnPosition);
        }
        static Vector3 GetEffectPosition(FacingDirection fd, Transform moveEffectTransform)
        {
            Vector3 offset = GetOffset(fd);

            return moveEffectTransform.position + offset;
            static Vector3 GetOffset(FacingDirection fd)
            {
                switch (fd)
                {
                    case FacingDirection.Down:
                        return new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0.1f);
                    case FacingDirection.Up:
                        return new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0);
                    case FacingDirection.Left:
                    case FacingDirection.Right:
                        return new Vector3(0f, UnityEngine.Random.Range(0, 0.06f));
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}