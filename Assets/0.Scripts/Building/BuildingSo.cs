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
   
   
   
   public bool CanInstall(Dictionary<BuildingType , int> dictionary)
   {
      for (int i = 0; i < needResources.Length; i++)
      {
         if (dictionary[needResources[i].type]  < needResources[i].amount)
         {
            Debug.Log("자원이 부족합니다..");
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
   public BuildingType type;
   public int amount;
}


