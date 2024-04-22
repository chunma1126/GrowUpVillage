using System;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float radius;
    public GameObject npc;
    
    public Transform villageHall;
        
    public int maxNpc;
    public int currentNpc;

    public float generateTime;
    
    private float time;

    private List<GameObject> npcsList = new List<GameObject>();

    public Transform target;
    
    public void Init(float _radius  ,int _maxNpc , float _generateTime ,Transform _villageHall,  GameObject _npc)
    {
        villageHall = _villageHall;
        radius = _radius;
        npc = _npc;
        maxNpc = _maxNpc;
        generateTime = _generateTime;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , radius);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;
        
        if(npc == null && npcsList.Count >= maxNpc)return;
        
        GenerationNpc();
        
    }

    private void GenerationNpc()
    {
        if (time > generateTime && currentNpc < maxNpc)
        {
            currentNpc++;
            
            GameObject newNpc = Instantiate(npc, villageHall.position , Quaternion.identity);
            newNpc.transform.SetParent(transform);
            
            newNpc.GetComponent<Npc>().SetVillageHall(villageHall);
            newNpc.GetComponent<Npc>().SetWorkShopTrm(target);
            npcsList.Add(newNpc);
            
            time = 0;
        }
    }

    public Transform GetTargetTrm()
    {
        return target.transform;
    }
}