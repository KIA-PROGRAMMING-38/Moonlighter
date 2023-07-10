using Enums;
using System;
using UnityEngine;

public class BodyEffectController : MonoBehaviour
{
    private PlayerCharacter _player;

    private Transform _moveEffectTransform;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _player = transform.root.GetComponent<PlayerCharacter>();
        _moveEffectTransform = transform.Find("MoveEffectPosition");
    }

    private void PlayMoveEffect()
    {
        Vector3 footEffectSpawnPosition = GetFootEffectSpawnPosition(_player.PlayerFacingDirection);
        Managers.Effect.PlayEffect(EffectId.MoveEffect, footEffectSpawnPosition);
    }

    private void PlayRollEffect()
    {
        Vector3 footEffectSpawnPosition = GetFootEffectSpawnPosition(_player.PlayerFacingDirection);
        Managers.Effect.PlayEffect(EffectId.RollEffect, footEffectSpawnPosition);
    }

    private Vector3 GetFootEffectSpawnPosition(FacingDirection dir)
    {
        Vector3 offset = GetOffset(dir);

        return _moveEffectTransform.position + offset;
        static Vector3 GetOffset(FacingDirection dir)
        {
            switch (dir)
            {
                case FacingDirection.Down:
                    return new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0.1f);
                case FacingDirection.Up:
                    return new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0f);
                case FacingDirection.Left:
                    return new Vector3(0f, UnityEngine.Random.Range(-0.02f, 0.04f));
                case FacingDirection.Right:
                    return new Vector3(0f, UnityEngine.Random.Range(-0.02f, 0.04f));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}