using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerRollState RollState { get; private set; }

    [SerializeField]
    private PlayerData _playerData;

    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "Move");
        RollState = new PlayerRollState(this, StateMachine, _playerData, "Roll");

        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions
    public void SetVelocity(Vector2 velocity)
    {
        workspace = velocity;
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    #endregion

    #region Other Functions

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion
}
