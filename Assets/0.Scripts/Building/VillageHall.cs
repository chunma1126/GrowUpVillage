using System;
using System.Collections.Generic;
using TMPro;
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

    public Dictionary<ResourceType, int> _resourceDictionary { get; private set; }

    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI rockText;
    [SerializeField] private TextMeshProUGUI foodText;
    
    private void Start()
    {
        _resourceDictionary = new Dictionary<ResourceType, int>();

        foreach (ResourceType item in Enum.GetValues(typeof(ResourceType)))
        {
            _resourceDictionary.Add(item, 0);
            
        }

    }

    public void AddResource(ResourceType type,int amount)
    {
        _resourceDictionary[type] += amount;

        UpdateText(type);
    }

    public void UpdateText(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Food:
                foodText.SetText(_resourceDictionary[type].ToString());
                break;
            case ResourceType.Wood:
                woodText.SetText(_resourceDictionary[type].ToString());
                break;
            case ResourceType.Rock:
                rockText.SetText(_resourceDictionary[type].ToString());
                break;
        }
    }
}
