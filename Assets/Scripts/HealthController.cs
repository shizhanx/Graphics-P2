using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject createOnDestroy;
    public float hp;
    private GameObject player;
    public float exp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void ApplyDamage(float damage)
    {
        if (!(tag == "Player" && GetComponent<PlayerController>().invincible))
        {
            hp -= damage;
        }
        if (hp <= 0)
        {
            //    GameObject explosion = Instantiate(characterExplosionPrefab);
            //    explosion.transform.position = transform.position;
            if(tag == "Enemy")
            {
                GetComponent<DropItemController>().Drop();
                player.GetComponent<LevelController>().GainEXP(exp);
            }
            Destroy(this.gameObject);
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;
        }
    }

    public void Regen(float amount)
    {
        hp += amount;
        if (tag == "Player")
        {
            float max = GetComponent<PlayerController>().maxHP;
            if (hp > max)
            {
                hp = max;
            }
        }
    }
}
