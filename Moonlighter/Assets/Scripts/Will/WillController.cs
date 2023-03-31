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
    /// WALK 상태일 때 StateMachineBehaviour에 이동을 구현하기 위한 함수.
    /// </summary>
    public void ApplyMovePosition()
    {
        _rigid.MovePosition(_rigid.position + _will.MoveInput * (_will.MoveSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// ROLL 상태일 때 StateMachineBehaviour에 이동을 구현하기 위한 함수.
    /// </summary>
    /// <param name="rollDirection"></param>
    public void ApplyRollPosition(Vector2 rollDirection)
    {
        _rigid.MovePosition(_rigid.position + rollDirection * (_will.RollSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// 애니메이터에 입력에 따른 X축 이동에 대한 파라미터를 넘겨주기 위한 함수.
    /// </summary>
    /// <returns></returns>
    public float AnimMoveX()
    {
        return _will.MoveInput.x;
    }

    /// <summary>
    /// 애니메이터에 입력에 따른 Y축 이동에 대한 파라미터를 넘겨주기 위한 함수.
    /// </summary>
    /// <returns></returns>
    public float AnimMoveY()
    {
        return _will.MoveInput.y;
    }

    /// <summary>
    /// 이동키의 입력값을 StateMachineBehaviour에게 알려주기 위한 함수.
    /// </summary>
    /// <returns></returns>
    public Vector2 MoveInput()
    {
        return _will.MoveInput;
    }

    /// <summary>
    /// ROLL 키가 입력됬음을 StateMachineBehaviour에게 알려주기 위한 함수.
    /// </summary>
    /// <returns></returns>
    public bool RollInput()
    {
        return _rolling;
    }

    /// <summary>
    /// ROLL이 끝났을 때 구르기 값을 false로 바꿔주는 함수. 
    /// </summary>
    public void RollFinish()
    {
        _rolling = false;
    }

    #region InputSystem 관련 함수.
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
