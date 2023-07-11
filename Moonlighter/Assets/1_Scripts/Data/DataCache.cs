using System.Collections.Generic;
using UnityEngine;

public sealed class DataCache<T> where T : Object
{
    private Dictionary<string, T> _table = new();

    public T Load(string filename)
    {
        if (false == _table.ContainsKey(filename))
        {
            T resource = Managers.Resource.Load<T>(filename);
            _table[filename] = resource;

            return resource;
        }
        return _table[filename];
    }

    public T this[string filename]
    {
        get => _table[filename];
        set => _table[filename] = value;
    }
}
