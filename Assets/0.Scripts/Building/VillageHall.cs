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
    Army,
    Church
}

[Serializable]
public class VillageHallStat
{
    public float happy;
    public float loyalty;
    public float technology;
    public float culture;
}

public class VillageHall : MonoBehaviour
{
    public VillageHallStat stat;
    public float currentResource;
    private BuildingManager _buildingManager;
        
    public Dictionary<BuildingType, int> _resourceDictionary { get; private set; }
    
    [Header("Resources")]
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI rockText;
    [SerializeField] private TextMeshProUGUI foodText;
    
    [Header("Stat")]
    [SerializeField] private TextMeshProUGUI happyText;
    [SerializeField] private TextMeshProUGUI loyaltyText;
    [SerializeField] private TextMeshProUGUI technologyText;
    [SerializeField] private TextMeshProUGUI cultureText;
    
    [SerializeField] private Transform icons;
    [SerializeField] private GameObject buildingIconPrefab;

    [SerializeField] private List<Npc> nightNpcs;
    
    private void Start()
    {
        nightNpcs = new List<Npc>();
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

        UpdateStat();
    }

    private void Update()
    {
        if (GameManager.Instance.IsNight() == false && nightNpcs.Count > 0)
        {
            foreach (var item in nightNpcs)
            {
                item.gameObject.SetActive(true);
                nightNpcs.Remove(item);
            }
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


    public void UpdateStat()
    {
        happyText.SetText(stat.happy.ToString());
        loyaltyText.SetText(stat.loyalty.ToString());
        technologyText .SetText(stat.technology.ToString());
        cultureText.SetText(stat.culture.ToString());
    }

    public void AddNpcInNight(Npc newNpc)
    {
        nightNpcs.Add(newNpc);
    }
    
}
