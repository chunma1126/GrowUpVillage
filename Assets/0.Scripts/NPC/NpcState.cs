
public class NpcState
{
   protected Npc npc { get; private set; }
   protected NpcStateMachine stateMachine { get; private set; }
   protected string animBoolName { get; private set; }

   protected bool endTriggerCalled;
   
   public NpcState(Npc newNpc , NpcStateMachine  newStateMachine , string animBoolName )
   {
      npc = newNpc;
      stateMachine = newStateMachine;
      this.animBoolName = animBoolName;
   }
   
   public virtual void Enter()
   {
      npc.Animator.SetBool(animBoolName , true);
      endTriggerCalled = false;
   }
   
   public virtual void Update()
   {
      
   }
    
   public virtual void Exit()
   {
      npc.Animator.SetBool(animBoolName, false);
   }

   public void AnimationTriggerCall()
   {
      endTriggerCalled = true;
   }
   
}
