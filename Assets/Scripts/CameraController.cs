using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 view;
    // Start is called before the first frame update
    void Start()
    {
        view = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + view;
            transform.LookAt(player);
        }
    }
}
