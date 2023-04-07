using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Grounded State")]
    public float MovementVelocity = 1.0f;

    [Header("Ability State")]
    public float RollingVelocity = 1.5f;
}
