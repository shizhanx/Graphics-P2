using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bullets;
    public GameObject bulletTemplate;
    private Rigidbody rb;
    private Vector3 move;
    private float X = 0;
    private float Z = 0;
    private float shootCD = 0;
    public float maxHP;
    public float damage;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHP = 100f;
        damage = 10;
        GetComponent<HealthController>().hp = maxHP;
        attackSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            X = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            X = 1;
        }
        shootCD += Time.deltaTime;
        
        Vector2 mouseScreenPos = Input.mousePosition;
        float distanceFromCameraToXZPlane = Camera.main.transform.position.y - transform.position.y;
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        Vector3 mouseToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);
        transform.LookAt(mouseToWorldPos);

        if (Input.GetKey(KeyCode.Space))
        {
            if (shootCD > attackSpeed)
            {
                GameObject bullet = Instantiate(bulletTemplate, bullets.transform);
                BulletController controller = bullet.GetComponent<BulletController>();
                controller.transform.position = transform.position + transform.forward * 0.5f;
                controller.velocity = (mouseToWorldPos - controller.transform.position).normalized;
                controller.ally="Player";
                controller.toDamage = "Enemy";
                controller.damage = damage;
                shootCD = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        move = new Vector3(X * Time.deltaTime * speed, 0, Z * Time.deltaTime * speed);
        rb.MovePosition(rb.position + move);
        X = 0;
        Z = 0;
    }
}
