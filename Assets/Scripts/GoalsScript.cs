using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI soulText;
    int money;
    int moneyGoal;
    int soulGoal;
    int souls;
    int day;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        money = 0;
        souls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(day == 1)
        {
            moneyGoal = 100;
            soulGoal = 50;
        }
        if (day == 2)
        {
            moneyGoal = 170;
            soulGoal = 100;
        }
        if (day == 3)
        {
            moneyGoal = 150;
            soulGoal = 250;
        }
        moneyText.text = ("Money: " + money + ("/") + moneyGoal);
        soulText.text = ("Money: " + souls + ("/") + soulGoal);
    }
}
