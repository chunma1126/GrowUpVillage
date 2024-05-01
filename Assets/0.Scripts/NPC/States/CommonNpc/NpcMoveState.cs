using System.Timers;
using UnityEngine;
using UnityEngine.Rendering;

public class NpcMoveState : NpcState
{
    private Transform target;
    private float runSpeed;
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

        SetSpeedAndAnim();
        
        if(npc.GetDistance(npc.transform , npc.target) >= npc.interactionRange)
            npc.movement.SetDestination(npc.target);
        else
            stateMachine.ChangeState(npc.IdleState);
    }

    private void SetSpeedAndAnim()
    {
        
        if (npc.GetDistance(npc.transform, npc.target) >= npc.runRadius)
        {
            npc.movement.SetSpeed(npc.runSpeed);
            npc.Animator.SetFloat("Run",1 , 0.25f , Time.deltaTime);
        }
        else
        {
            npc.movement.SetSpeed(npc.walkSpeed);
            npc.Animator.SetFloat("Run", 0 , 0.25f , Time.deltaTime);
        }
    }

    public override void Exit()
    {
        base.Exit();
        npc.movement.agent.isStopped = true;

    }
}
