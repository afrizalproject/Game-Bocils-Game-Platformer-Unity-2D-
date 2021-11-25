using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManajer : MonoBehaviour
{
    public static GoalManajer singletone;

    public int holywaterNeed;
    public int holywaterCollected;
    public bool enterGoal;

    public Text scorwaterUI;


    private void Awake()
    {
        singletone = this;
    }

    public void ColledtedHolyWater()
    {
        holywaterCollected++;
        scorwaterUI.text = "= " + holywaterCollected.ToString();
        if (holywaterCollected >= holywaterNeed)
        {
            enterGoal = true;
        }
    }
}
