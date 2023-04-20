using UnityEngine;

public class RocketArmBody : MonoBehaviour
{
    public CapsuleCollider2D Collider { get; private set; }

    private void Awake()
    {
        Collider = GetComponent<CapsuleCollider2D>();
    }

    private void ActiveRocketArmAttack()
    {
        Collider.enabled = true;
    }

    private void InactiveRocketArmAttack()
    {
        Collider.enabled = false;
    }
}
