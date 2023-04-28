using System.Collections.Generic;
using UnityEngine;

public static class TimeStore
{
    private static readonly Dictionary<float, WaitForSecondsRealtime> _container = new Dictionary<float, WaitForSecondsRealtime>();

    public static WaitForSecondsRealtime GetWaitForSeconds(float seconds)
    {
        if (false == _container.ContainsKey(seconds))
        {
            _container.Add(seconds, new WaitForSecondsRealtime(seconds));
        }

        return _container[seconds];
    }
}