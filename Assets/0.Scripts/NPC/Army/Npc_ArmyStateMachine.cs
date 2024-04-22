using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_ArmyStateMachine 
{
    public Npc_ArmyState CurrentState { get; private set; }

    public void Initialize(Npc_ArmyState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }
    
    public void ChangeState(Npc_ArmyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
