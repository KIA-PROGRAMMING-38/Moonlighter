public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    public PlayerState PrevState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        PrevState = CurrentState;
        CurrentState = newState;
        CurrentState.Enter();
    }
}
