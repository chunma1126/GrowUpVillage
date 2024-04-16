using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public NpcStateMachine NpcStateMachine { get; private set; }

    #region States

    public NpcIdleState IdleState { get; private set; }
    public NpcMoveState MoveState { get; private set; }

    public NpcWorkState WorkState { get; private set; }

    #endregion
    
    public Animator Animator { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }

    public float maxResource;
    public float currentResource;

    public Transform myHouse;
    
    private void Awake()
    {
        NpcStateMachine = new NpcStateMachine();
        
        IdleState = new NpcIdleState(this , NpcStateMachine , "Idle");
        MoveState = new NpcMoveState(this , NpcStateMachine , "Move");
        WorkState = new NpcWorkState(this , NpcStateMachine , "Work");
    }

    void Start()
    {
        myHouse = transform.parent;
        
        Animator = GetComponentInChildren<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        
        NpcStateMachine.Initialize(IdleState);
    }
    void Update()
    {
        NpcStateMachine.currentState.Update();
    }

    public void AnimationEnd()
    {
        NpcStateMachine.currentState.AnimationTriggerCall();
    }
    
    
}
