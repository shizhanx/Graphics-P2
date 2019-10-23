using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    public GameObject HPRegenController;
    public int[] dropRates;
    
    public void Drop()
    {
        if (Random.Range(0, 100) < dropRates[0])
        {
            GameObject HPRegen = Instantiate(HPRegenController);
            HPRegen.transform.position = transform.position;
        }
    }
}
