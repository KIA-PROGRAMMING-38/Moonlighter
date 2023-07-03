using System.Collections.Generic;
using UnityEngine;

public static class WaitForSecondsCache
{
    private static Dictionary<float, WaitForSeconds> _waitForSeconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float seconds)
    {
        if (false == _waitForSeconds.ContainsKey(seconds))
        {
            _waitForSeconds.Add(seconds, new WaitForSeconds(seconds));
        }

        return _waitForSeconds[seconds];
    }
}