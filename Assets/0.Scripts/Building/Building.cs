using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float radius;
    public GameObject npc;
    
  
        
    public int maxNpc;
    public int currentNpc;

    public float generateTime;
    
    private float time;

    private List<GameObject> npcsList = new List<GameObject>();
    public List<Transform> ways;
    
    public Transform villageHall;
    public Transform target;
    
    public void Init(float _radius  ,int _maxNpc , float _generateTime ,Transform _villageHall,  GameObject _npc)
    {
        villageHall = _villageHall;
        radius = _radius;
        npc = _npc;
        maxNpc = _maxNpc;
        generateTime = _generateTime;
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one , 0.4f).SetEase(Ease.OutBack);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , radius);
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
            
            newNpc.GetComponent<Agent>().SetVillageHall(villageHall);
            
            (newNpc.GetComponent<Agent>() as Npc)?.SetWorkShopTrm(target);

            (newNpc.GetComponent<Agent>() as Npc_Army)?.SetWays(ways);
            
            npcsList.Add(newNpc);
            time = 0;
        }
    }

   
}