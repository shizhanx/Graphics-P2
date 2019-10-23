using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //    GameObject explosion = Instantiate(characterExplosionPrefab);
            //    explosion.transform.position = transform.position;
            if(tag == "Enemy")
            {
                GetComponent<DropItemController>().Drop();
            }
            Destroy(this.gameObject);
        }
    }

    public void Regen(float amount)
    {
        hp += amount;
        if (tag == "palyer")
        {
            float max = GetComponent<PlayerController>().maxHP;
            if (hp > max)
            {
                hp = max;
            }
        }
    }
}
