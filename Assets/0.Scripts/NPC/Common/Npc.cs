using UnityEngine;
using UnityEngine.Serialization;


public class Npc : Agent
{
    public NpcStateMachine NpcStateMachine { get; private set; }
    public NpcMovement movement { get; private set; }
    
    #region States
    public NpcIdleState IdleState { get; private set; }
    public NpcMoveState MoveState { get; private set; }
    public NpcWorkState WorkState { get; private set; }
    public NpcDanceState DanceState { get; private set; }

    #endregion
    
    public Animator Animator { get; private set; }
        
    [Header("ResourcesValue")]
    public BuildingType buildingType;
    public int maxResource;
    public int currentResource;

    [Header("NpcValue")] 
    public float workSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float runRadius = 10;
    
    [HideInInspector] public Transform workShopTrm;
    public float interactionRange;

    public Transform target;
    public GameObject workItem;
        
    protected virtual void Awake()
    {
        NpcStateMachine = new NpcStateMachine();
        
        IdleState = new NpcIdleState(this , NpcStateMachine , "Idle");
        MoveState = new NpcMoveState(this , NpcStateMachine , "Move");
        WorkState = new NpcWorkState(this , NpcStateMachine , "Work");
        DanceState = new NpcDanceState(this , NpcStateMachine , "Dance");
    }
    
    protected virtual void Start()
    {

        movement = GetComponent<NpcMovement>();
        Animator = GetComponentInChildren<Animator>();
        
        NpcStateMachine.Initialize(IdleState);
                
        
    }
    protected virtual void Update()
    {
        NpcStateMachine.CurrentState.Update();
    }

    public override void AnimationEnd()
    {
        NpcStateMachine.CurrentState.AnimationTriggerCall();
    }

    public virtual void SetWorkShopTrm(Transform workShop)
    {
        workShopTrm = workShop;
    }
    
    
    public float GetDistance(Transform npc , Transform target)
    {
        return Vector3.Distance(npc.position , target.position);
    }
   


}
