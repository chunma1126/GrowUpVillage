using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDanceState : NpcState
{
    public NpcDanceState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if (endTriggerCalled)
        {
            stateMachine.ChangeState(npc.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
