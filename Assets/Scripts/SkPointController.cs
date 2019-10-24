using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkPointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<LevelController>().skPoint+=1;
            Destroy(this.gameObject);
        }
    }
}
