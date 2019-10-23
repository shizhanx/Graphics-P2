﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Rigidbody rb;
    private float maxHP = 50;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        GetComponent<HealthController>().hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        rb.MovePosition(rb.position+transform.forward*Time.deltaTime*speed);
    }
}
