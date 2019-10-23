using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegenController : MonoBehaviour
{
    public float rotationSpeed;
    private float heal = 20;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(Time.deltaTime * rotationSpeed, new Vector3(0, 1, 0));
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
