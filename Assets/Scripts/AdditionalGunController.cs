using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalGunController : MonoBehaviour
{
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
            other.gameObject.GetComponent<PlayerController>().guns += 1;
            Text prompt = Instantiate(promptTemplete, UI.transform);
            prompt.text = "Additional Gun";
            Destroy(this.gameObject);
        }
    }
}
