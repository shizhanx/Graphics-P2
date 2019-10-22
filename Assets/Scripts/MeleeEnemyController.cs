using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody rb;
    private float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        maxHP = 50f;
        GetComponent<HealthController>().hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+transform.forward*Time.deltaTime*speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }
}
