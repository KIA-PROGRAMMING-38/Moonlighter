using DG.Tweening;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Pool;

public class EffectManager
{
    private Dictionary<string, AnimatorController> _effects = new Dictionary<string, AnimatorController>();

    public ObjectPool<GameObject> EffectPool { get; set; }

    public void Init()
    {
        EffectPool = new ObjectPool<GameObject>(GenerateEffect, ActiveEffect);
    }

    public GameObject GenerateEffect()
    {
        GameObject go = Managers.Resource.Instantiate("Effect");
        Effect effect = go.GetComponent<Effect>();
        effect.Pool = EffectPool;
        return go;
    }

    public void ActiveEffect(GameObject effect)
    {
        effect.SetActive(true);
    }

    private AnimatorController GetEffectAnim(string path)
    {
        AnimatorController animController = null;
        if (_effects.TryGetValue(path, out animController))
            return animController;

        animController = Managers.Resource.Load<AnimatorController>(path);
        _effects.Add(path, animController);
        return animController;
    }

    private void ResetPrefabInfo(GameObject prefab)
    {
        SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();
        sr.material.color = new Color(1, 1, 1, 1);

        prefab.transform.localScale = new Vector3(1, 1, 1);
        prefab.transform.rotation = Quaternion.Euler(Vector3.zero);

    }

    public void PlayMoveEffect(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        GameObject moveEffect = EffectPool.Get();
        ResetPrefabInfo(moveEffect);

        Animator anim = moveEffect.GetComponent<Animator>();
        anim.runtimeAnimatorController = GetEffectAnim("EffectAC/MoveEffectAC");

        SpriteRenderer sr = moveEffect.GetComponent<SpriteRenderer>();
        sr.material.color = new Color(1, 1, 1, 0.5f);

        moveEffect.transform.position = position;
        moveEffect.transform.rotation = Quaternion.Euler(rotation);
        moveEffect.transform.localScale = scale;
    }

    public void PlayRollEffect(Vector3 position, Vector3 rotation)
    {
        GameObject rollEffect = EffectPool.Get();
        ResetPrefabInfo(rollEffect);

        Animator anim = rollEffect.GetComponent<Animator>();
        anim.runtimeAnimatorController = GetEffectAnim("EffectAC/RollEffectAC");
        int rollEffectIndex = Random.Range(0, 4);
        Debug.Log(rollEffectIndex);
        anim.SetInteger("effectNum", rollEffectIndex);

        SpriteRenderer sr = rollEffect.GetComponent<SpriteRenderer>();
        sr.material.DOColor(new Color(1, 1, 1, 0), 0.5f);

        rollEffect.transform.position = position;
        rollEffect.transform.DOLocalRotate(rotation, 0.4f);

    }

}