using DG.Tweening;
using System.Collections;
using UniRx.Toolkit;
using UnityEditor.Animations;
using UnityEngine;

public class BodyEffectController : MonoBehaviour
{
    private static readonly int _footCount = 2;

    #region MoveEffect Variables
    private Transform[] _footPositions = new Transform[_footCount];
    private Transform _moveEffects;
    private Vector3 _moveEffectScale = new Vector3(0.3f, 0.3f, 1);
    private Vector3 _moveEffeectRotation = new Vector3(0, 0, -90);
    private Color _moveEffectColor = new Color(1, 1, 1, 0.5f);
    private int _footNum = 0;
    #endregion

    #region RollEffect Variables
    private Vector3 _rollEffectEndRotation = new Vector3(0, 0, 180);
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _moveEffects = transform.Find("MoveEffectPos");

        for (int i = 0; i < _footPositions.Length; ++i)
        {
            _footPositions[i] = _moveEffects.GetChild(i);
        }

    }

    private void PlayMoveEffect()
    {
        Managers.Effect.PlayMoveEffect(_footPositions[_footNum].position, _moveEffeectRotation, _moveEffectScale);
        ++_footNum;
        _footNum %= _footCount;
    }

    private void PlayRollEffect()
    {
        Managers.Effect.PlayRollEffect(_footPositions[_footNum].position, _rollEffectEndRotation);
        ++_footNum;
        _footNum %= _footCount;
    }
}