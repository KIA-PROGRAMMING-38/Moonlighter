using DG.Tweening;
using Enums;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager
{
    private GameObject _baseEffectPrefab;

    private const string _effectPath = "EffectAC/";

    public Dictionary<string, AnimatorController> Effects { get; private set; }

    public ObjectPool<GameObject> EffectPool { get; private set; }

    public void Init()
    {
        _baseEffectPrefab = Managers.Resource.Load<GameObject>("Prefabs/Effect/BaseEffect");
        Effects = new Dictionary<string, AnimatorController>();
        EffectPool = new ObjectPool<GameObject>(GenerateEffect, ActiveEffect);
    }

    public GameObject GenerateEffect()
    {
        GameObject go = Managers.Resource.Instantiate(_baseEffectPrefab);

        EffectController effect = go.GetComponent<EffectController>();
        return go;
    }

    public void ActiveEffect(GameObject effect)
    {
        effect.SetActive(true);
    }

    public void PlayEffect(EffectId effectId, Vector3 position)
    {
        GameObject effect = EffectPool.Get();

        Animator anim = effect.GetComponent<Animator>();
        string effectAnimController = Managers.Data.EffectDataTable[(int)effectId].Name;
        anim.runtimeAnimatorController = Effects.Load<AnimatorController>($"{_effectPath}{effectAnimController}");

        effect.transform.position = position;
    }
}