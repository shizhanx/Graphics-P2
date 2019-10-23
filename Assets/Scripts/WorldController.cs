using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    public Text instruction;
    public Text quests;
    private ArrayList swarmPoints;
    private int progress;
    public GameObject player;
    public GameObject swarmTemplete;
    public GameObject meleeTemplete;
    public GameObject rangeTemplete;
    private enum Stages {movement, shoot, melee, range, levelup, item, swarm, endtut, realfight}
    private Stages stage;

    // Start is called before the first frame update
    void Start()
    {
        swarmPoints =new ArrayList{new Vector3(-97,0.5f,45), new Vector3(45, 0.5f, 46), new Vector3(95, 0.5f, 111), new Vector3(124, 0.5f, -20),
        new Vector3(92,0.5f,-89), new Vector3(59,0.5f,-63), new Vector3(-21,0.5f,-85)};
        stage = Stages.movement;
        instruction.text = "Welcome to 打手冲, let's first\ntry move aronud with wasd";
        quests.text = "Find exit 0/1";
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case Stages.movement:
                if (player.transform.position.z < -85)
                {
                    instruction.text = "牛逼嗷，会走路了嗷, next let's\ntry aim with mouse and\nshoot with left click";
                    quests.text = "Shoot 5 times "+progress+"/5";
                    stage = Stages.shoot;
                    player.GetComponent<PlayerController>().bulletShooted = 0;
                }
                break;
            case Stages.shoot:
                if (progress >= 5)
                {
                    progress = 0;
                    instruction.text = "Careful! Zombies are coming\nKill 'em or they kill you";
                    quests.text = "Kill zombies 0/2";
                    stage = Stages.melee;
                    GameObject melee = Instantiate(meleeTemplete, new Vector3(-125, 0.5f, -125), transform.rotation, transform);
                    melee.GetComponent<DropItemController>().dropRates = new int[] { 0 };
                    melee = Instantiate(meleeTemplete, new Vector3(-100, 0.5f, -120), transform.rotation, transform);
                    melee.GetComponent<DropItemController>().dropRates = new int[] { 0 };
                }
                else
                {
                    progress = player.GetComponent<PlayerController>().bulletShooted;
                    quests.text = "Shoot 5 times " + progress + "/5";
                }
                break;
            case Stages.melee:
                if (progress >= 2)
                {
                    progress = 0;
                    instruction.text = "Bone rangers love shooting\nespecially shooting at you";
                    quests.text = "Kill rangers 0/2";
                    stage = Stages.range;
                    GameObject range = Instantiate(rangeTemplete, new Vector3(-125, 0.5f, -125), transform.rotation, transform);
                    range.GetComponent<DropItemController>().dropRates = new int[] { 0 };
                    range = Instantiate(rangeTemplete, new Vector3(-100, 0.5f, -120), transform.rotation, transform);
                    range.GetComponent<DropItemController>().dropRates = new int[] { 0 };
                }
                else
                {
                    progress = 2 - transform.childCount;
                    quests.text = "Kill zombies " + progress + "/2";
                }
                break;
            case Stages.range:
                if (progress >= 2)
                {
                    progress = 0;
                    instruction.text = "You've leveled up\nFollow the instruction\nand pick a power-up";
                    quests.text = "Use sk point 0/1";
                    stage = Stages.levelup;
                }
                else
                {
                    progress = 2 - transform.childCount;
                    quests.text = "Kill rangers " + progress + "/2";
                }
                break;
            case Stages.levelup:
                if (player.GetComponent<LevelController>().skPoint == 0)
                {
                    instruction.text = "Enemies may drop item\nto regen your HP, kill\nthis ranger and see";
                    quests.text = "Pick op item 0/1";
                    GameObject range = Instantiate(rangeTemplete, new Vector3(-100, 0.5f, -120), transform.rotation, transform);
                    range.GetComponent<DropItemController>().dropRates = new int[] { 100 };
                    player.GetComponent<HealthController>().hp -= 20;
                    player.GetComponent<PlayerController>().invincible = true;
                    stage = Stages.item;
                }
                break;
            case Stages.item:
                if (player.GetComponent<HealthController>().hp == 100)
                {
                    instruction.text = "A swarm will infinitely\ngenerate enemies, find and\ndestroy it!";
                    quests.text = "Destroy swarm 0/1";
                    player.GetComponent<PlayerController>().invincible = false;
                    GameObject swarm = Instantiate(swarmTemplete, new Vector3(-94, 0.5f, -137), transform.rotation, transform);
                    swarm.GetComponent<DropItemController>().dropRates = new int[] { 0 };
                    stage = Stages.swarm;
                }
                break;
            case Stages.swarm:
                if (transform.childCount == 0)
                {
                    instruction.text = "You've finished tutorial\nGet outside and start\nthe real fight!";
                    quests.text = "Get outside 0/1";
                    stage = Stages.endtut;
                }
                break;
            case Stages.endtut:
                if (player.transform.position.x > -80)
                {
                    instruction.enabled=false;
                    quests.text = "Destroy swarm 0/3";
                    while (transform.childCount < 3)
                    {
                        int index=Random.Range(0, swarmPoints.Count);
                        GameObject swarm = Instantiate(swarmTemplete, (Vector3)swarmPoints[index], transform.rotation, transform);
                        swarmPoints.RemoveAt(index);
                    }
                    stage = Stages.realfight;
                }
                break;
            case Stages.realfight:
                quests.text = "Destroy swarm "+(3-transform.childCount)+"/3";
                break;
        }
    }
}
