using UnityEngine;

public class Agent : MonoBehaviour
{
  
   public VillageHall VillageHall { get; private set; }
   [HideInInspector] public Transform villageHallTrm;
   public virtual void AnimationEnd()
   {
      
   }

   public virtual void SetVillageHall(Transform villageHall)
   {
      this.villageHallTrm = villageHall;
      VillageHall = villageHallTrm.GetComponentInParent<VillageHall>();
   }
}
