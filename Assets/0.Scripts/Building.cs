using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float radius;
    public GameObject npc;
    public GameObject prefab;
    
    public int maxNpc;
    public int currentNpc;
    
    private float time;

    private List<GameObject> npcsList = new List<GameObject>();

    public void Init(float _radius , GameObject _prefab , GameObject _npc,int _maxNpc)
    {
        radius = _radius;
        prefab = _prefab;
        npc = _npc;
        maxNpc = _maxNpc;
    }
    
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , radius);
    }

    private void Update()
    {
        time += Time.deltaTime;
        
        if(npc == null)return;
        GenerationNpc();

    }

    private void GenerationNpc()
    {
        if (time > 5 && currentNpc < maxNpc)
        {
            currentNpc++;
            
            GameObject newNpc = Instantiate(npc, transform);
            npcsList.Add(newNpc);
            
            time = 0;
        }
    }
}