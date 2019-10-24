using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    public GameObject meleeTemplete;
    public GameObject rangeTemplate;
    private float spawnCD = 5;
    private float spawnTime = 5;
    private float maxHP = 500;
    private float exp = 20;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthController>().hp = maxHP;
        GetComponent<HealthController>().exp = exp;
        GetComponent<DropItemController>().dropRates = new int[] { 0,0 };
    }

    // Update is called once per frame
    void Update()
    {
        spawnCD += Time.deltaTime;
        if (spawnCD > spawnTime)
        {
            spawnCD = 0;
            int spawnType = Random.Range(0, 2);
            float xOffset = Random.Range(-2f, 2f);
            float zOffset = Mathf.Sqrt(2f*2f-xOffset*xOffset) * Random.Range(0, 2) * 2 - 1;
            Vector3 offset = new Vector3(xOffset, 0, zOffset);
            GameObject enemy;
            switch (spawnType)
            {
                case 1:
                    enemy = Instantiate(rangeTemplate);
                    enemy.GetComponent<DropItemController>().dropRates = new int[] { 20,25 };
                    break;
                default:
                    enemy = Instantiate(meleeTemplete);
                    enemy.GetComponent<DropItemController>().dropRates = new int[] { 20,25 };
                    break;
            }
            enemy.transform.position = transform.position + offset;
        }
    }
}
