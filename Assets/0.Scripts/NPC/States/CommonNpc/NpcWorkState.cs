using System.Collections;
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
        
        if(npc.workItem != null)
            npc.workItem.SetActive(true);
        
        float happyStat =  npc.VillageHall.stat.happy/10;
        
        
        if (Random.Range(0,100) <= happyStat)
        {
           stateMachine.ChangeState(npc.DanceState);
        }
        else
        {
            npc.workSpeed = npc.VillageHall.stat.happy;
            npc.Animator.speed = npc.workSpeed;
        }
        
        npc.workSpeed = npc.VillageHall.stat.happy;
        npc.Animator.speed = npc.workSpeed;
    }

    public override void Update()
    {
        base.Update();
        if (endTriggerCalled)
        {
            stateMachine.ChangeState(npc.IdleState);
            
            if (npc.maxResource <= npc.currentResource)
            {
                npc.target = npc.villageHallTrm;
                stateMachine.ChangeState(npc.MoveState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        
        if(npc.workItem != null)
            npc.workItem.SetActive(false);
        
        npc.Animator.speed = 1;
    }

}
