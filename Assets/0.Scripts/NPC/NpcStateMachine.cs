

public class NpcStateMachine
{
    public NpcState CurrentState { get; private set; }

    public void Initialize(NpcState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }
    
    public void ChangeState(NpcState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    
    
}
