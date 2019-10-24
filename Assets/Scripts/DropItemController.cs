using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    public GameObject HPRegen;
    public GameObject SkPoint;
    public int[] dropRates;
    
    public void Drop()
    {
        int rand = Random.Range(0, 100);
        GameObject drop;
        if (rand < dropRates[0])
        {
            drop = Instantiate(HPRegen);
            drop.transform.position = transform.position;
        }else if(rand>=dropRates[0] && rand < dropRates[1])
        {
            drop = Instantiate(SkPoint);
            drop.transform.position = transform.position;
        }
    }
}
