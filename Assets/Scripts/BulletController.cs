using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public string ally;
    public string toDamage;
    public float damage;
    public GameObject bulletExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += transform.forward*0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Untagged" || other.gameObject.tag == toDamage)
        {
            if (other.gameObject.tag == toDamage)
            {
                HealthController hp = other.gameObject.GetComponent<HealthController>();
                hp.ApplyDamage(damage);
            }
//            GameObject explosion = Instantiate(bulletExplosionPrefab);
//            explosion.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
