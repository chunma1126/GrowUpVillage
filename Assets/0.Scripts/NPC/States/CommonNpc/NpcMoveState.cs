using UnityEngine;

public class NpcMoveState : NpcState
{
    private Transform target;
    public NpcMoveState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }
    
    public override void Enter()
    {
        base.Enter();
        
        npc.movement.agent.isStopped = false;
        
        target = npc.target;
    }

    public override void Update()
    {
        base.Update();
        
        if(npc.GetDistance(npc.transform , npc.target) >= npc.interactionRange)
            npc.movement.SetDestination(npc.target);
        else
            stateMachine.ChangeState(npc.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
        npc.movement.agent.isStopped = true;

    }
}
