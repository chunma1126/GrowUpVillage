using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcWorkState : NpcState
{
    public NpcWorkState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        npc.currentResource++;
    }

    public override void Update()
    {
        base.Update();

        if (endTriggerCalled && npc.currentResource >= npc.maxResource)
        {
            stateMachine.ChangeState(npc.MoveState);
        }
        else if(endTriggerCalled)
        {
            stateMachine.ChangeState(npc.IdleState);
        }
                
    }

    public override void Exit()
    {
        base.Exit();
       
    }
}
