using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class Npc_Army : Agent
{
    public Animator Animator { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public NpcMovement Movement { get; private set; }

    #region States
    public Npc_ArmyStateMachine ArmyStateMachine { get; private set; }
    public Npc_ArmyIdleState IdleState { get; private set; }
    public Npc_ArmyMoveState MoveState { get; private set; }
    public Npc_ArmyAttackState AttackState { get; private set; }
    
    #endregion
    public Rig leftHandArm;
    public List<Transform> ways;
    public Transform target;
    public int wayIndex;
    
    public LayerMask whatIsEnemy;
    
    [Header("Attack Values")]
    public float attackRadius;
    public float checkRadius;
    public float attackSpeed;
    public float attackDamage;
    
    
    private void Awake()
    {
        ArmyStateMachine = new Npc_ArmyStateMachine();
        
        IdleState = new Npc_ArmyIdleState(this , ArmyStateMachine , "Idle");
        MoveState = new Npc_ArmyMoveState(this , ArmyStateMachine , "Move");
        AttackState = new Npc_ArmyAttackState(this , ArmyStateMachine , "Attack");
    }

    private void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Movement = GetComponent<NpcMovement>();
        
        ArmyStateMachine.Initialize(IdleState);
        leftHandArm.weight = 0;
    }

    private void Update()
    {
        ArmyStateMachine.CurrentState.Update();
    }

    public Collider IsRangeInEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position , checkRadius , whatIsEnemy);
        return cols.Length > 0 ?  cols[0] : null;
    }
        
    public override void AnimationEnd()
    {
        ArmyStateMachine.CurrentState.AnimationTriggerCall();
    }

    public void RigWeight(float endValue , float duration)
    {
        StartCoroutine(RigWeightCoroutine(endValue , duration));
    }
    
    private IEnumerator RigWeightCoroutine(float endValue, float duration)
    {
        float startTime = Time.time;
        float startWeight = leftHandArm.weight;

        while (Time.time - startTime < duration)
        {
            float normalizedTime = (Time.time - startTime) / duration;
            float currentValue = Mathf.Lerp(startWeight, endValue, normalizedTime);
            leftHandArm.weight = currentValue;
            yield return null;
        }
        leftHandArm.weight = endValue;
    }

    public void SetWays(List<Transform> ways)
    {
        this.ways = ways;
    }
}
