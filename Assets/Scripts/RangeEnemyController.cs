using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyController : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Transform bullets;
    public GameObject bulletTemplate;
    private Rigidbody rb;
    private float maxHP = 30;
    private float maxDistance = 7;
    private float attackSpeed = 2;
    private float shootCD = 0;
    private float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        rb = GetComponent<Rigidbody>();
        GetComponent<HealthController>().hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            rb.MovePosition(rb.position + transform.forward * Time.deltaTime * speed);
        }
        shootCD += Time.deltaTime;
        if (shootCD > attackSpeed)
        {
            GameObject bullet = Instantiate(bulletTemplate, bullets);
            BulletController controller = bullet.GetComponent<BulletController>();
            controller.transform.position = transform.position + transform.forward * 0.5f;
            controller.velocity = (player.transform.position - controller.transform.position).normalized;
            controller.ally = "Enemy";
            controller.toDamage = "Player";
            controller.damage = damage;
            shootCD = 0;
        }
    }
}
