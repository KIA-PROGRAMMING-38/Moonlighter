using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Will : MonoBehaviour
{
    public enum WillState
    {
        IDLE,
        WALK,
        ROLL
    }

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
