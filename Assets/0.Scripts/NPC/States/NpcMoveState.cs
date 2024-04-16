using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMoveState : NpcState
{
    public NpcMoveState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        
        npc.NavMeshAgent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();
        
        if(Vector3.Distance(npc.transform.position , npc.myHouse.position) >= 1.5f)
            npc.NavMeshAgent.SetDestination(npc.myHouse.position);
        else
            stateMachine.ChangeState(npc.WorkState);
    }

    public override void Exit()
    {
        base.Exit();

        npc.NavMeshAgent.isStopped = true;
    }
}
