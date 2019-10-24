using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPRegenController : MonoBehaviour
{
    private float heal = 20;
    public Text promptTemplete;
    private GameObject UI;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthController>().Regen(heal);
            Text prompt = Instantiate(promptTemplete, UI.transform);
            prompt.text = "HP+20";
            Destroy(this.gameObject);
        }
    }
}
