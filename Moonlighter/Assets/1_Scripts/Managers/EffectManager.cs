using DG.Tweening;
using Enums;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager
{
    private GameObject _baseEffectPrefab;
    private Color _originColor;


    public ObjectPool<GameObject> EffectPool { get; set; }

    public void Init()
    {
        _baseEffectPrefab = Managers.Resource.Load<GameObject>("Prefabs/Effect");
        _originColor = Color.white;
        EffectPool = new ObjectPool<GameObject>(GenerateEffect, ActiveEffect);
        
    }

    public GameObject GenerateEffect()
    {
        GameObject go = Managers.Resource.Instantiate(_baseEffectPrefab);

        EffectController effect = go.GetComponent<EffectController>();
        effect.Pool = EffectPool;
        return go;
    }

    public void ActiveEffect(GameObject effect)
    {
        ResetPrefabInfo(effect);
        effect.SetActive(true);
    }

    private void ResetPrefabInfo(GameObject prefab)
    {
        prefab.GetComponent<Animator>().runtimeAnimatorController = null;

        SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();
        sr.DOColor(_originColor, 0);

        prefab.transform.localScale = Vector3.one;
        prefab.transform.rotation = Quaternion.Euler(Vector3.zero);

    }

    public void PlayEffect(EffectId effectId, Vector3 position)
    {
        GameObject effect = EffectPool.Get();

        Animator anim = effect.GetComponent<Animator>();
        string effectAnimController = Managers.Data.EffectAnimatorControllerDataTable[(int)effectId].AnimatorControllerPath;
        anim.runtimeAnimatorController = Managers.Resource.Load<AnimatorController >(effectAnimController);

        effect.transform.position = position;
    }
}