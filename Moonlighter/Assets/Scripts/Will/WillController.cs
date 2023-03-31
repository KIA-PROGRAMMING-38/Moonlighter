using UnityEngine;
using UnityEngine.InputSystem;

public class WillController : MonoBehaviour
{
    private Will _will;
    private Rigidbody2D _rigid;
    
    private bool _rolling;

    public Will.WillState CurrentState
    {
        get
        {
            return _will.CurrentState;
        }
        set
        {
            _will.CurrentState = value;
        }
    }

    public Will.WillState PrevState
    {
        get
        {
            return _will.PrevState;
        }
        set
        {
            _will.PrevState = value;
        }
    }

    public Will.IdleDirection IdleDir
    {
        get
        {
            return _will.Dir;
        }
        set
        {
            _will.Dir = value;
        }
    }

    private void Awake()
    {
        _will = GetComponent<Will>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// WALK ������ �� StateMachineBehaviour�� �̵��� �����ϱ� ���� �Լ�.
    /// </summary>
    public void ApplyMovePosition()
    {
        _rigid.MovePosition(_rigid.position + _will.MoveInput * (_will.MoveSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// ROLL ������ �� StateMachineBehaviour�� �̵��� �����ϱ� ���� �Լ�.
    /// </summary>
    /// <param name="rollDirection"></param>
    public void ApplyRollPosition(Vector2 rollDirection)
    {
        _rigid.MovePosition(_rigid.position + rollDirection * (_will.RollSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// �ִϸ����Ϳ� �Է¿� ���� X�� �̵��� ���� �Ķ���͸� �Ѱ��ֱ� ���� �Լ�.
    /// </summary>
    /// <returns></returns>
    public float AnimMoveX()
    {
        return _will.MoveInput.x;
    }

    /// <summary>
    /// �ִϸ����Ϳ� �Է¿� ���� Y�� �̵��� ���� �Ķ���͸� �Ѱ��ֱ� ���� �Լ�.
    /// </summary>
    /// <returns></returns>
    public float AnimMoveY()
    {
        return _will.MoveInput.y;
    }

    /// <summary>
    /// �̵�Ű�� �Է°��� StateMachineBehaviour���� �˷��ֱ� ���� �Լ�.
    /// </summary>
    /// <returns></returns>
    public Vector2 MoveInput()
    {
        return _will.MoveInput;
    }

    /// <summary>
    /// ROLL Ű�� �Է����� StateMachineBehaviour���� �˷��ֱ� ���� �Լ�.
    /// </summary>
    /// <returns></returns>
    public bool RollInput()
    {
        return _rolling;
    }

    /// <summary>
    /// ROLL�� ������ �� ������ ���� false�� �ٲ��ִ� �Լ�. 
    /// </summary>
    public void RollFinish()
    {
        _rolling = false;
    }

    #region InputSystem ���� �Լ�.
    void OnMove(InputValue value)
    {
        _will.MoveInput = value.Get<Vector2>();
    }

    void OnRoll()
    {
        _rolling = true;
    }
    #endregion
}
