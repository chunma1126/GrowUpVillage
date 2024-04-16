using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdleState : NpcState
{
    private float stateTimer;
    
    public NpcIdleState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }
    
    public override void Enter()
    {
        base.Enter();
        
        stateTimer = 0.7f;
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        
        if(stateTimer >= 0)return;
                
        if (Vector3.Distance(npc.transform.position , npc.myWorkTrm.position) <= 1.5f)
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
