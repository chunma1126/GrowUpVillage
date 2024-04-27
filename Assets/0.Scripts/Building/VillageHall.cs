using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BuildingType
{
    Food,
    Rock,
    Wood,
    Army
}

public class VillageHall : MonoBehaviour
{
    public float currentResource;

    private BuildingManager _buildingManager;
    
    public Dictionary<BuildingType, int> _resourceDictionary { get; private set; }

    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI rockText;
    [SerializeField] private TextMeshProUGUI foodText;

    [SerializeField] private Transform icons;
    [SerializeField] private GameObject buildingIconPrefab;

    private void Start()
    {
        _resourceDictionary = new Dictionary<BuildingType, int>();
        _buildingManager = GetComponent<BuildingManager>();
        
        foreach (BuildingType item in Enum.GetValues(typeof(BuildingType)))
        {
            _resourceDictionary.Add(item, 0);
        }


        int index = 0;
        foreach (BuildingType item in Enum.GetValues(typeof(BuildingType)))
        {
            string name = item.ToString();
            GameObject newIcon = Instantiate(buildingIconPrefab, icons);

            newIcon.GetComponentInChildren<TextMeshProUGUI>().SetText(name);
    
            int currentIndex = index;

            newIcon.GetComponent<Button>().onClick.AddListener(() => _buildingManager.ChangeBuildings(currentIndex)); // 복사한 변수를 사용
            index++;
        }

    }

    public void AddResource(BuildingType type,int amount)
    {
        _resourceDictionary[type] += amount;

        UpdateText(type);
    }

    public void UpdateText(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Food:
                foodText.SetText(_resourceDictionary[type].ToString());
                break;
            case BuildingType.Wood:
                woodText.SetText(_resourceDictionary[type].ToString());
                break;
            case BuildingType.Rock:
                rockText.SetText(_resourceDictionary[type].ToString());
                break;
        }
    }
}
