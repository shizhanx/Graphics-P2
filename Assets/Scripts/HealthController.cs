using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int hp;
    public GameObject characterExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ApplyDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameObject explosion = Instantiate(characterExplosionPrefab);
            explosion.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
