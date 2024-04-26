using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_ArmyAttackState : Npc_ArmyState
{
    public Npc_ArmyAttackState(Npc_Army newNpc, Npc_ArmyStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Npc.Animator.speed = Npc.attackSpeed;
                
        Npc.transform.forward = (Npc.target.position - Npc.transform.position).normalized;
        
                
        
         Npc.RigWeight(1,0.35f);
    }

    public override void Update()
    {
        base.Update();
        if (endTriggerCalled)
        {
            StateMachine.ChangeState(Npc.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Npc.Animator.speed = 1;
        Npc.RigWeight(0, 0.35f);
    }
}
