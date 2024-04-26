using UnityEngine;


public class Npc_ArmyMoveState : Npc_ArmyState
{
    public Npc_ArmyMoveState(Npc_Army newNpc, Npc_ArmyStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Npc.Movement.agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();
        if (Vector3.Distance(Npc.transform.position , Npc.target.position) <= Npc.attackRadius)
        {
            StateMachine.ChangeState(Npc.IdleState);
        }
        else
        {
            Npc.Movement.SetDestination(Npc.target);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Npc.Movement.agent.isStopped = true;
    }
}