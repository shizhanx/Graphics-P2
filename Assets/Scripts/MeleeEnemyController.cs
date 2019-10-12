using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
}
