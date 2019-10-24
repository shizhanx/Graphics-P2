using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    RectTransform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        trans.localPosition = new Vector3(0, 30, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.localPosition.y > 50)
        {
            Destroy(this.gameObject);
        }
        else
        {
            trans.localPosition += Vector3.up * Time.deltaTime * 10;
        }
    }
}
