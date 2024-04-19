using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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

    public bool interacting;
    public float interactionRange;
        
    [HideInInspector] public Transform workShop;
    [HideInInspector] public Transform villageHallTrm;

    public LayerMask whatIsEnemy;
    public LayerMask whatIsObstacle;

    public Transform target;
    
    protected virtual void Awake()
    {
        NpcStateMachine = new NpcStateMachine();
        
        IdleState = new NpcIdleState(this , NpcStateMachine , "Idle");
        MoveState = new NpcMoveState(this , NpcStateMachine , "Move");
        WorkState = new NpcWorkState(this , NpcStateMachine , "Work");
    }

    protected virtual void Start()
    {
        workShop = transform.parent;

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
        VillageHall = villageHallTrm.GetComponent<VillageHall>();
    }
    
    public float GetDistance(Transform npc , Transform target)
    {
        return Vector3.Distance(npc.position , target.position);
    }
   


}
