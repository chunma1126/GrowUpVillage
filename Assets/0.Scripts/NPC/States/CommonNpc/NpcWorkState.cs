

using System.Linq;

public class NpcWorkState : NpcState
{
    public NpcWorkState(Npc newNpc, NpcStateMachine newStateMachine, string animBoolName) : base(newNpc, newStateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        npc.currentResource++;
        npc.shovel.SetActive(true);
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
        npc.shovel.SetActive(false);
       
    }
}
