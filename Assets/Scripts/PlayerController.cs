using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text stats;
    private Transform bullets;
    public GameObject bulletTemplate;
    private Rigidbody rb;
    private Vector3 move;
    private float X = 0;
    private float Z = 0;
    private float shootCD = 0;
    public float maxHP;
    public float damage;
    public float attackSpeed;
    public int bulletShooted;
    public bool invincible;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject[] gunObjects;
    public int guns;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-130, 0.5f, -60);
        rb = GetComponent<Rigidbody>();
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        maxHP = 100f;
        damage = 10;
        GetComponent<HealthController>().hp = maxHP;
        attackSpeed = 1f;
        bulletShooted = 0;
        invincible = false;
        gun2.GetComponent<MeshRenderer>().enabled = false;
        gun3.GetComponent<MeshRenderer>().enabled = false;
        gunObjects = new GameObject[] { gun1, gun2, gun3 };
        guns = 1;
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

        gunObjects[guns - 1].GetComponent<MeshRenderer>().enabled = true;
        if (Input.GetMouseButton(0))
        {
            if (shootCD > attackSpeed)
            {
                for (int i = 0; i < guns; i++)
                {
                    GameObject bullet = Instantiate(bulletTemplate, bullets);
                    BulletController controller = bullet.GetComponent<BulletController>();
                    bullet.transform.position = transform.position;
                    controller.transform.LookAt(gunObjects[i].transform);
                    controller.ally="Player";
                    controller.toDamage = "Enemy";
                    controller.damage = damage;
                    bulletShooted += 1;
                }
                shootCD = 0;
            }
        }

        stats.text = "Damage: " + damage.ToString("F2") + "\nAttack Speed: " + attackSpeed.ToString("F2") + "sec" +
            "\nHP: " + GetComponent<HealthController>().hp.ToString("F2") + "\nExp: " + GetComponent<LevelController>().currentExp +
            "/" + (int)GetComponent<LevelController>().maxExp;
    }

    private void FixedUpdate()
    {
        move = new Vector3(X * Time.deltaTime * speed, 0, Z * Time.deltaTime * speed);
        rb.MovePosition(rb.position + move);
        X = 0;
        Z = 0;
        rb.velocity = new Vector3(0,0,0);
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Ground" && rb.constraints!=RigidbodyConstraints.FreezePositionY)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    public void Initialize()
    {
        maxHP = 100f;
        damage = 10;
        GetComponent<HealthController>().hp = maxHP;
        attackSpeed = 1f;
        bulletShooted = 0;
        invincible = false;
        guns = 1;
        gun2.GetComponent<MeshRenderer>().enabled = false;
        gun3.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<LevelController>().Initialize();
    }
}
