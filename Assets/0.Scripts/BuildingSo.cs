using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingSo" , menuName = "SO/Buillding")]
public class BuildingSo : ScriptableObject
{
   public string buildingName;
   public float buildingRadius;
   public int maxNpc;
   public float generateTime;
   public NeedResources[] needResources;
   public GameObject prefab;
   public GameObject npc;
   
   public bool CanInstall(Dictionary<ResourceType , int> dictionary)
   {
      for (int i = 0; i < needResources.Length; i++)
      {
         if (dictionary[needResources[i].type]  < needResources[i].amount)
         {
            return false;
         }
         dictionary[needResources[i].type] -= needResources[i].amount;
      }

      return true;
   }
   
}

[System.Serializable]
public struct NeedResources
{
   public ResourceType type;
   public int amount;
}


