using UnityEngine;

public class BossWave : MonoBehaviour
{
    public Collider2D Collider { get; private set; }

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void ActiveWaveAttack()
    {
        Collider.enabled = true;
    }

    private void InactiveWaveAttack()
    {
        Collider.enabled = false;
    }
}
