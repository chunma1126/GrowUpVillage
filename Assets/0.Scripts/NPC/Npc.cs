using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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

    public VillageHall VillageHall { get; private set; }

    [Header("Resources")] 
    public float maxResource;
    public float currentResource;
    
    [HideInInspector] public Transform myWorkTrm;
    [HideInInspector] public Transform villageHallTrm;
    
    
    private void Awake()
    {
        NpcStateMachine = new NpcStateMachine();
        
        IdleState = new NpcIdleState(this , NpcStateMachine , "Idle");
        MoveState = new NpcMoveState(this , NpcStateMachine , "Move");
        WorkState = new NpcWorkState(this , NpcStateMachine , "Work");
    }

    void Start()
    {
        myWorkTrm = transform.parent;
        
        Animator = GetComponentInChildren<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
                
        NpcStateMachine.Initialize(IdleState);

        
    }
    void Update()
    {
        NpcStateMachine.CurrentState.Update();
    }

    public void AnimationEnd()
    {
        NpcStateMachine.CurrentState.AnimationTriggerCall();
    }

    public void SetVillageHall(Transform villageHall)
    {
        this.villageHallTrm = villageHall;
        VillageHall = villageHallTrm.GetComponent<VillageHall>();
    }
        
}
