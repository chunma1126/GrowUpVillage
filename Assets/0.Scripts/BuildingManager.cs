using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingManager : MonoBehaviour
{
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
    }

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBuildings = buildingList[0];
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBuildings = buildingList[1];
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBuildings = buildingList[2];
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray , out RaycastHit hit , whatIsGround))
            {
                Collider[] around = Physics.OverlapSphere(hit.point,currentBuildings.buildingRadius);
                
                foreach (var item in around)
                {
                    
                    if (item.GetComponent<Building>())
                    {
                        return;
                    }
                }
                GameObject newBuilding = Instantiate(currentBuildings.prefab , hit.point , Quaternion.identity);
                newBuilding.transform.Rotate(new Vector3(0 , buildingRotation , 0));
                
                Building newBuildingCompo =  newBuilding.GetComponent<Building>();
                
                newBuildingCompo.Init(currentBuildings.buildingRadius, currentBuildings.maxNpc , currentBuildings.generateTime , villageTarget, currentBuildings.npc);
                
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
}