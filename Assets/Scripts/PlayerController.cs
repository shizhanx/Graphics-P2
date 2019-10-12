using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = 0;
        float Z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            Z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            X -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            X += 1;
        }
        move = new Vector3(X * Time.deltaTime * speed, 0, Z * Time.deltaTime * speed);
        
        Vector2 mouseScreenPos = Input.mousePosition;
        float distanceFromCameraToXZPlane = Camera.main.transform.position.y - transform.position.y;
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        Vector3 mouseToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);
        transform.LookAt(mouseToWorldPos);
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + move);
    }
}
