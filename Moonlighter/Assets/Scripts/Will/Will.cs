using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Will : MonoBehaviour
{
    public enum WillState
    {
        IDLE,
        RUN
    }

    [Header("MoveSpeed")]
    public float MoveSpeed;

    [Header("MoveInput")]
    public Vector2 MoveInput;

    [Header("State")]
    public WillState State;

}
