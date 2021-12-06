using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{
    public GameObject panelStory;
    public GameObject panelControl;
    public GameObject panelCredit;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void story()
    {
        panelStory.SetActive(true);
    }

    public void control()
    {
        panelControl.SetActive(true);
    }

    public void credit()
    {
        panelCredit.SetActive(true);
    }

    public void panelClose()
    {
        panelStory.SetActive(false);
        panelControl.SetActive(false);
        panelCredit.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
        print("Quit!");
    }
}
