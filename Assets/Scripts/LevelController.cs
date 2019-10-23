using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private int level;
    public int skPoint;
    public float maxExp;
    public float currentExp;
    public Text prompt;
    public int promptDir=1;
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
            prompt.rectTransform.localPosition += Vector3.up * Time.deltaTime * 10 * promptDir;
            if (prompt.rectTransform.localPosition.y > 60)
            {
                promptDir = -1;
            }else if (prompt.rectTransform.localPosition.y < 50)
            {
                promptDir = 1;
            }
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
        while (currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level += 1;
            skPoint += 1;
            maxExp *= 1.5f;
        }
    }

    public void Initialize()
    {
        level = 1;
        skPoint = 0;
        maxExp = 10;
        currentExp = 0;
    }
}
