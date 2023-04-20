using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttackEffect : MonoBehaviour
{
    public ObjectPool<PlayerAttackEffect> Pool { get; set; }

    private void ProjectileToPool()
    {
        Pool.Release(this);
        gameObject.SetActive(false);
    }
}
