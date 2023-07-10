using DG.Tweening;
using Enums;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager
{
    private GameObject _baseEffectPrefab;

    private const string EFFECT_PATH = "EffectAC/";

    private DataCache<AnimatorController> _effectTable;

    private ObjectPool<EffectController> _effectPool;

    public void Init()
    {
        _baseEffectPrefab = Managers.Resource.Load<GameObject>("Prefabs/Effect/BaseEffect");
        _effectTable = new DataCache<AnimatorController>();
        _effectPool = new ObjectPool<EffectController>(GenerateEffect, ActiveEffect);
    }

    public EffectController GenerateEffect()
    {
        GameObject go = Managers.Resource.Instantiate(_baseEffectPrefab);
        
        EffectController effectController = go.GetComponent<EffectController>();

        Debug.Assert(effectController is not null);

        return effectController;
    }

    private void ActiveEffect(EffectController effect) => effect.gameObject.SetActive(true);

    public void ReleaseToPool(EffectController effect) => _effectPool.Release(effect);

    public void PlayEffect(EffectId effectId, Vector3 position)
    {
        EffectController effect = _effectPool.Get();

        Animator anim = effect.GetComponent<Animator>();
        string effectAnimController = Managers.Data.EffectDataTable[(int)effectId].AnimationControllerName;
        anim.runtimeAnimatorController = _effectTable.Load(Path.Combine(EFFECT_PATH, effectAnimController));

        effect.transform.position = position;
    }
}