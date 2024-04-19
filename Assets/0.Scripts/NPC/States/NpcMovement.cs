using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
   public NavMeshAgent agent;
   
   private void Awake()
   {
      agent = GetComponent<NavMeshAgent>();
   }

   
   public void SetDestination(Transform newTarget)
   {
      agent.SetDestination(newTarget.position);
   }
}
