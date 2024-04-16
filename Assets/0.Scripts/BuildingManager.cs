using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Ray _ray;
    [SerializeField] private BuildingSo building;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float buildingRotation;
    
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray , out RaycastHit hit , whatIsGround))
            {
                Collider[] around = Physics.OverlapSphere(hit.point,building.buildingRadius);

                foreach (var item in around)
                {
                    if(item.GetComponent<Building>())
                        return;
                }
                GameObject newBuilding = Instantiate(building.prefab , hit.point , Quaternion.identity);
                newBuilding.transform.Rotate(new Vector3(0 , buildingRotation , 0));
                
                Building newBuildingCompo =  newBuilding.GetComponent<Building>();
                
                newBuildingCompo.Init(building.buildingRadius, building.maxNpc , building.generateTime , transform, building.npc);
                
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