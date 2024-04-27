using UnityEngine;


public class Npc_ArmyIdleState : Npc_ArmyState
{
    private float timer;
    public Npc_ArmyIdleState(Npc_Army newNpc, Npc_ArmyStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        timer = 1.2f;
    }

    public override void Update()
    {
        base.Update();
        
        timer -= Time.deltaTime;
        
        if (timer > 0)return;

        Collider enemy = Npc.IsRangeInEnemy();

        if (enemy != null)
        {
            Npc.target = enemy.transform;  
            
            if (Vector3.Distance(Npc.transform.position , enemy.transform.position) <= Npc.attackRadius)
            {
                StateMachine.ChangeState(Npc.AttackState);
            }
            else
            {
                StateMachine.ChangeState(Npc.MoveState);
            }
        }
        else
        {
            int targetWaysIndex = Npc.wayIndex % Npc.ways.Count;
            
            Npc.target = Npc.ways[targetWaysIndex];
            StateMachine.ChangeState(Npc.MoveState);
            
            Npc.wayIndex++;
            
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}