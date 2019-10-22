using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public string tagToDamage;
    public int damage;
    public GameObject bulletExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagToDamage)
        {
            HealthController hp = collision.gameObject.GetComponent<HealthController>();
            hp.ApplyDamage(damage);
        }
        GameObject explosion = Instantiate(bulletExplosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
