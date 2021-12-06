using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager singleton;
    public GameObject warningScore;

    public int hurufNeeded, hurufCollected;
    public bool canEnterFinish=false;

    private void Awake()
    {
        singleton = this;
    }

    public void CollectHuruf()
    {
        hurufCollected++;
        if (hurufCollected == hurufNeeded)
        {
            canEnterFinish = true;
        }
    }

    IEnumerator warningUITurnOff()
    {
        yield return new WaitForSeconds(5);
        warningScore.SetActive(false);
    }

    public void runCoroutine()
    {
        StartCoroutine(warningUITurnOff());
    }


}
