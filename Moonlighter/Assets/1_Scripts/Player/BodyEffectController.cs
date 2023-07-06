using Enums;
using UnityEngine;

public class BodyEffectController : MonoBehaviour
{
    private PlayerCharacter _player;

    private Transform _moveEffectPos;
    private Vector3 _footPosition;
    private Vector3 _footPositionOffset;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _player = transform.root.GetComponent<PlayerCharacter>();
        _moveEffectPos = transform.Find("MoveEffectPosition");
    }

    private void PlayMoveEffect()
    {
        SetFootPositionOffset();
        Managers.Effect.PlayEffect(EffectId.MoveEffect, _footPosition);
    }

    private void PlayRollEffect()
    {
        SetFootPositionOffset();
        Managers.Effect.PlayEffect(EffectId.RollEffect, _footPosition);
    }

    private void SetFootPositionOffset()
    {
        _footPositionOffset = Vector3.zero;
        switch (_player.PlayerFacingDirection)
        {
            case FacingDirection.Down:
                _footPositionOffset.y += 0.1f;
                _footPositionOffset.x = Random.Range(-0.04f, 0.04f);
                _footPosition = _moveEffectPos.position + _footPositionOffset;
                break;
            case FacingDirection.Up:
                _footPositionOffset.x = Random.Range(-0.04f, 0.04f);
                _footPosition = _moveEffectPos.position + _footPositionOffset;
                break;
            case FacingDirection.Left:
                _footPositionOffset.y = Random.Range(-0.02f, 0.04f);
                _footPosition = _moveEffectPos.position + _footPositionOffset;
                break;
            case FacingDirection.Right:
                _footPositionOffset.y = Random.Range(-0.02f, 0.04f);
                _footPosition = _moveEffectPos.position + _footPositionOffset;
                break;
            default:
                Debug.Log($"Player Facing Direction Error{_player.PlayerFacingDirection}");
                return;
        }
    }
}