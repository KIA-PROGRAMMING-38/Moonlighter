using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WillController : MonoBehaviour
{
    private Will _will;
    private Rigidbody2D _rigid;
    private Animator _anim;

    private void Awake()
    {
        _will = GetComponent<Will>();
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    public void ApplyMovePosition()
    {
        _rigid.MovePosition(_rigid.position + _will.MoveInput * (_will.MoveSpeed * Time.fixedDeltaTime));
    }

    public float AnimMoveX()
    {
        return _will.MoveInput.x;
    }

    public float AnimMoveY()
    {
        return _will.MoveInput.y;
    }

    public Vector2 MoveInput()
    {
        return _will.MoveInput;
    }

    void OnMove(InputValue value)
    {
        _will.MoveInput = value.Get<Vector2>();
    }
}
