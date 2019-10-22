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
            float xOffset = Random.Range(-2f, 2f);
            float zOffset = Mathf.Sqrt(2f*2f-xOffset*xOffset) * Random.Range(0, 2) * 2 - 1;
            Vector3 offset = new Vector3(xOffset, 0, zOffset);
            GameObject melee = Instantiate(meleeTemplete);
            melee.transform.parent = transform;
            melee.transform.position = transform.position + offset;
        }
    }
}
