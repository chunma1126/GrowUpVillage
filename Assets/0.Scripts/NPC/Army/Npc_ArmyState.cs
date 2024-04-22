using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_ArmyState
{
    protected Npc_Army Npc { get; private set; }
    protected Npc_ArmyStateMachine StateMachine { get; private set; }
    protected string AnimBoolName { get; private set; }

    protected bool endTriggerCalled;
   
    public Npc_ArmyState(Npc_Army newNpc  , Npc_ArmyStateMachine  newStateMachine , string animBoolName )
    {
        Npc = newNpc;
        StateMachine = newStateMachine;
        this.AnimBoolName = animBoolName;
    }
   
    public virtual void Enter()
    {
        Npc.Animator.SetBool(AnimBoolName , true);
        endTriggerCalled = false;
    }
   
    public virtual void Update()
    {
      
    }
    
    public virtual void Exit()
    {
        Npc.Animator.SetBool(AnimBoolName, false);
    }

    public void AnimationTriggerCall()
    {
        endTriggerCalled = true;
    }
    
   
}
