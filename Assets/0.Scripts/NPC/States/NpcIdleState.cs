using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdleState : NpcState
{
    
    
    public NpcIdleState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }
    
    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();

        if (Vector3.Distance(npc.transform.position , npc.myHouse.position) <= 1.5f)
        {
            stateMachine.ChangeState(npc.WorkState);
        }
        else
        {
            stateMachine.ChangeState(npc.MoveState);
        }
        
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }
}
