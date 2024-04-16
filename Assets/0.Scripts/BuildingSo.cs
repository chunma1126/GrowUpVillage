using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingSo" , menuName = "SO/Buillding")]
public class BuildingSo : ScriptableObject
{
   public string buildingName;
   public float buildingRadius;
   public int maxNpc;
   public GameObject prefab;
   public GameObject npc;
   
   
   
}