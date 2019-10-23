using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private int level;
    private int skPoint;
    private float maxExp;
    private float currentExp;
    public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        skPoint = 0;
        maxExp = 10;
        currentExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (skPoint > 0)
        {
            prompt.GetComponent<Text>().enabled = true;
            PlayerController controller = GetComponent<PlayerController>();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                controller.damage *= 1.25f;
                skPoint -= 1;
            }else if (Input.GetKeyDown(KeyCode.E))
            {
                controller.attackSpeed *= 0.8f;
                skPoint -= 1;
            }
        }
        else
        {
            prompt.GetComponent<Text>().enabled = false;
        }
    }

    public void GainEXP(float exp)
    {
        currentExp += exp;
        while (currentExp > maxExp)
        {
            currentExp -= maxExp;
            level += 1;
            skPoint += 1;
            maxExp *= 1.1f;
        }
    }
}
