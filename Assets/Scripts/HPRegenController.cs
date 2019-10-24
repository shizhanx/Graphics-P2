﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegenController : MonoBehaviour
{
    private float heal = 20;
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthController>().Regen(heal);
            Destroy(this.gameObject);
        }
    }
}
