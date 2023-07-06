using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<Type, Func<string, UnityEngine.Object>> _loadStrategies;

    private Dictionary<string, Material> _materials = new Dictionary<string, Material>();
    private Dictionary<string, AnimatorController> _effects = new Dictionary<string, AnimatorController>();

    public void Init()
    {
        _loadStrategies = new Dictionary<Type, Func<string, UnityEngine.Object>>
        {
            { typeof(Material),  LoadMaterial },
            { typeof(AnimatorController), LoadAnimatorController }
        };
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        if (_loadStrategies.TryGetValue(typeof(T), out var strategy))
        {
            return (T)strategy(path);
        }

        return Resources.Load<T>(path);
    }

    private Material LoadMaterial(string path)
    {
        if (!_materials.ContainsKey(path))
        {
            Material material = Resources.Load<Material>(path);
            _materials.Add(path, material);
        }

        return _materials[path];
    }

    private AnimatorController LoadAnimatorController(string path)
    {
        if (!_effects.ContainsKey(path))
        {
            AnimatorController animatorController = Resources.Load<AnimatorController>(path);
            _effects.Add(path, animatorController);
        }

        return _effects[path];
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Instantiate(prefab, parent);
    }

    public GameObject Instantiate(GameObject prefab, Transform parent = null)
    {
        GameObject go = UnityEngine.Object.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        UnityEngine.Object.Destroy(go);
    }
}