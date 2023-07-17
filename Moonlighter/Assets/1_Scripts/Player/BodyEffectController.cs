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
        Vector3 spawnPosition = GetFootEffectSpawnPosition(_player.PlayerFacingDirection);
        Managers.Effect.PlayEffect(EffectId.MoveEffect, spawnPosition);
    }

    private void PlayRollEffect()
    {
        Vector3 spawnPosition = GetFootEffectSpawnPosition(_player.PlayerFacingDirection);
        Managers.Effect.PlayEffect(EffectId.RollEffect, spawnPosition);
    }

    private Vector3 GetFootEffectSpawnPosition(FacingDirection dir)
    {
        Vector3 offset = GetOffset(dir);

        return _moveEffectTransform.position + offset;
        static Vector3 GetOffset(FacingDirection dir)
        {
            return dir switch
            {
                FacingDirection.Down => new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0.1f),
                FacingDirection.Up => new Vector3(UnityEngine.Random.Range(-0.04f, 0.04f), 0),
                FacingDirection.Left or FacingDirection.Right => new Vector3(0, UnityEngine.Random.Range(0, 0.06f)),
                _ => throw new NotImplementedException(nameof(GetOffset))
            };
        }
    }
}