using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _moveInput;
    public Vector2 MoveInput
    {
        get
        {
            return _moveInput.normalized;
        }
    }
    public bool RollInput { get; private set; }

    private void Start()
    {
        _moveInput = Vector2.zero;
    }

    private void Update()
    {
        _moveInput.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RollInput = Input.GetButtonDown("Roll");
        
    }
}