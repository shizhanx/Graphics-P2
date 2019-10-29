using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform lookAt;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(lookAt);
        transform.position = player.position;
        transform.position += transform.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt != null && player != null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }
            transform.position = player.position;
            transform.LookAt(lookAt);
            transform.position += transform.forward * 2;
            if (Vector3.Distance(transform.position, lookAt.position) < 3)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
