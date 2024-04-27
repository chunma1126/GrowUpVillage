using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuildingManager : MonoBehaviour
{
    private VillageHall _villageHall;
    
    private Ray _ray;
    [SerializeField] private BuildingSo currentBuildings;
    [SerializeField] private List<BuildingSo> buildingList;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float buildingRotation;
        
    [Header("target")]
    [SerializeField] private Transform villageTarget;

    private void Start()
    {
        currentBuildings = buildingList.First();
        _villageHall = GetComponent<VillageHall>();
    }

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Physics.Raycast(_ray , out RaycastHit hit , whatIsGround))
            {
                if (CheckBuildings(hit))
                    return;
                
                GenerateBuildings(hit);
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            buildingRotation += 15;
            
            if(buildingRotation >= 360)
            {
                buildingRotation -= 360;
            }
            
        }
    }

    private void GenerateBuildings(RaycastHit hit)
    {
        if (currentBuildings.CanInstall(_villageHall._resourceDictionary))
        {
            GameObject newBuilding = Instantiate(currentBuildings.prefab, hit.point, Quaternion.identity);
            newBuilding.transform.Rotate(new Vector3(0, buildingRotation, 0));

            Building newBuildingCompo = newBuilding.GetComponent<Building>();

            newBuildingCompo.Init(currentBuildings.buildingRadius, currentBuildings.maxNpc, currentBuildings.generateTime,
                villageTarget, currentBuildings.npc);
        
            
            //ui갱신
            foreach (BuildingType item in Enum.GetValues(typeof(BuildingType)))
            {
                _villageHall.UpdateText(item);
            }
        }
    }

    private bool CheckBuildings(RaycastHit hit)
    {
        Collider[] around = Physics.OverlapSphere(hit.point, currentBuildings.buildingRadius);

        foreach (var item in around)
        {
            if (item.GetComponent<Building>())
            {
                return true;
            }
        }

        return false;
    }


    public void ChangeBuildings(int index)
    {
        currentBuildings = buildingList[index];
    }
}