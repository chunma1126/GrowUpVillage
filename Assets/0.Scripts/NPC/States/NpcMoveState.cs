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

        if (npc.maxResource <= npc.currentResource)
        {
            npc.NavMeshAgent.SetDestination(npc.villageHallTrm.position);
            
            if (GetDistance(npc.transform , npc.villageHallTrm) <= 2f)
            {
                npc.VillageHall.AddResource(npc.currentResource);      
                npc.currentResource = 0;
                stateMachine.ChangeState(npc.IdleState);
            }
            return;
        }
        
        if(GetDistance(npc.transform , npc.myWorkTrm) >= 1f)
            npc.NavMeshAgent.SetDestination(npc.myWorkTrm.position);
        else
            stateMachine.ChangeState(npc.WorkState);
    }
    
    public override void Exit()
    {
        base.Exit();

        npc.NavMeshAgent.isStopped = true;
    }

    private float GetDistance(Transform npc , Transform target) //야인마 여기 npc 확인해야디 근데 MoveState에서는 npc 쓸 일 없긴하겠다
    {
        return Vector3.Distance(npc.position , target.position);
    }
}
