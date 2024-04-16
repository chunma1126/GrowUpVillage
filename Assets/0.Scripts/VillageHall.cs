using UnityEngine;

public class VillageHall : MonoBehaviour
{
    public float currentResource;

    public void AddResource(float amount)
    {
        currentResource += amount;
    }


}
