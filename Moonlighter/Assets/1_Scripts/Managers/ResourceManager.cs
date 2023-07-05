using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

    public void Init() { }

    public T Load<T>(string path) where T : Object
    {
        if(typeof(T) == typeof(Material))
        {
            if(false == _materials.ContainsKey(path))
            {
                Material material = Resources.Load<Material>(path);
                _materials.Add(path, material);
                return material as T;
            }

            return _materials[path] as T;
        }

        return Resources.Load<T>(path);
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
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}