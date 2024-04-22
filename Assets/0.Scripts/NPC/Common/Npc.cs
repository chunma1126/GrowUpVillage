using UnityEngine;


public class Npc : MonoBehaviour
{
    public NpcStateMachine NpcStateMachine { get; private set; }
    public NpcMovement movement { get; private set; }
    #region States
    public NpcIdleState IdleState { get; private set; }
    public NpcMoveState MoveState { get; private set; }
    public NpcWorkState WorkState { get; private set; }

    #endregion
    
    public Animator Animator { get; private set; }

    public VillageHall VillageHall { get; private set; }

    [Header("Resources")] 
    public float maxResource;
    public float currentResource;

    public float interactionRange;
        
    [HideInInspector] public Transform workShopTrm;
    [HideInInspector] public Transform villageHallTrm;

    public Transform target;
    public GameObject shovel;
    
    protected virtual void Awake()
    {
        NpcStateMachine = new NpcStateMachine();
        
        IdleState = new NpcIdleState(this , NpcStateMachine , "Idle");
        MoveState = new NpcMoveState(this , NpcStateMachine , "Move");
        WorkState = new NpcWorkState(this , NpcStateMachine , "Work");
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

    public virtual void AnimationEnd()
    {
        NpcStateMachine.CurrentState.AnimationTriggerCall();
    }

    public virtual void SetVillageHall(Transform villageHall)
    {
        this.villageHallTrm = villageHall;
        VillageHall = villageHallTrm.GetComponentInParent<VillageHall>();
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
