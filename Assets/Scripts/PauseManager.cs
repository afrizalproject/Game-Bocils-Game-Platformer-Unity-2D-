using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelControl;
    public void pauseButton()
    {
        if (Time.timeScale == 1)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
        }
        print("tes");
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void menuControl()
    {
        panelPause.SetActive(false);
        panelControl.SetActive(true);
    }

    public void backToPanelPause()
    {
        panelPause.SetActive(true);
        panelControl.SetActive(false);
    }
}
