using System;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Rock,
    Food
}

public class VillageHall : MonoBehaviour
{
    public float currentResource;

    private Dictionary<ResourceType, int> _resourceDictionary;
    
    
    private void Start()
    {
        _resourceDictionary = new Dictionary<ResourceType, int>();

        foreach (var item in Enum.GetNames(typeof(ResourceType)))
        {
            
        }

    }

    public void AddResource(ResourceType type,int amount)
    {
        _resourceDictionary[type] += amount;
    }

}
