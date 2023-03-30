using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WillController : MonoBehaviour
{
    private Will _will;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _will = GetComponent<Will>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckOnMove();
    }

    private void FixedUpdate()
    {
        _rigid.MovePosition(_rigid.position + _will.MoveInput * (_will.MoveSpeed * Time.fixedDeltaTime));
    }

    void OnMove(InputValue value)
    {
        _will.MoveInput = value.Get<Vector2>();
    }

    void CheckOnMove()
    {
        if (_will.MoveInput != Vector2.zero)
        {
            _will.State = Will.WillState.RUN;
        }
        else
        {
            _will.State = Will.WillState.IDLE;
        }
    }
}
