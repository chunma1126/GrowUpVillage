
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

        if (npc.maxResource <= npc.currentResource)
        {
            npc.VillageHall.AddResource(npc.currentResource);
            npc.currentResource = 0;
        }
        else if (npc.GetDistance(npc.transform , npc.workShopTrm) >= npc.interactionRange)
        {
            npc.target = npc.workShopTrm;
            stateMachine.ChangeState(npc.MoveState);   
        }
        else
        {
            stateMachine.ChangeState(npc.WorkState);
        }
        
                        
    }

    public override void Exit()
    {
        base.Exit();
        
    }
}
