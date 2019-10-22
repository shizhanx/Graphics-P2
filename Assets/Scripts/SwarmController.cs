using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    public GameObject meleeTemplete;
    private float spawnCD;
    private float spawnTime;
    private float maxHP = 1000;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthController>().hp = maxHP;
        spawnTime = 5;
        spawnCD = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCD += Time.deltaTime;
        if (spawnCD > spawnTime)
        {
            spawnCD = 0;
            GameObject melee = Instantiate(meleeTemplete);
            melee.transform.parent = transform;
            melee.transform.position = transform.position + transform.forward * 3f;
        }
    }
}
