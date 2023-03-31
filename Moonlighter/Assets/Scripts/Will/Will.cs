using UnityEngine;

public class Will : MonoBehaviour
{
    public enum WillState
    {
        IDLE,
        WALK,
        ROLL
    }

    // IDLE => ROLL로 상태가 변할때 구를 방향을 정해주기 위한 Enum값.
    public enum IdleDirection
    {
        DOWN,
        UP,
        LEFT,
        RIGHT
    }

    [Header("MoveSpeed")]
    public float MoveSpeed;

    [Header("RollSpeed")]
    public float RollSpeed;

    [Header("MoveInput")]
    public Vector2 MoveInput;

    [Header("CurrentState")]
    public WillState CurrentState;

    [Header("PrevState")]
    public WillState PrevState;

    [Header("Direction")]
    public IdleDirection Dir = IdleDirection.DOWN;

}
