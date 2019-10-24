using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkPointController : MonoBehaviour
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
            other.gameObject.GetComponent<LevelController>().skPoint+=1;
            Text prompt = Instantiate(promptTemplete, UI.transform);
            prompt.text = "SkPoint +1";
            Destroy(this.gameObject);
        }
    }
}
