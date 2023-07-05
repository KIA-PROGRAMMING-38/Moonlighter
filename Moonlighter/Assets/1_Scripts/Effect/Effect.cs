using UnityEngine;
using UnityEngine.Pool;

public class Effect : MonoBehaviour
{
    public ObjectPool<GameObject> Pool;

    private void DeactiveEffect()
    {
        Pool.Release(this.gameObject);
        this.gameObject.SetActive(false);
    }
}