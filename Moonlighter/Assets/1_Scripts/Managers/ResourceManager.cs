using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public Dictionary<string, Material> Material { get; private set; }

    public void Init()
    {
        Material = new Dictionary<string, Material>();
    }

    public T Load<T>(Dictionary<string, T> dic, string path) where T : Object
    {
        if (false == dic.ContainsKey(path))
        {
            T resource = Resources.Load<T>(path);
            dic.Add(path, resource);
            return dic[path];
        }

        return dic[path];
    }

    public T Load<T>(string path) where T : Object
    {
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
        GameObject go = UnityEngine.Object.Instantiate(prefab, parent);
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