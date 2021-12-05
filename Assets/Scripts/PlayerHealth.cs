using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] UIhealth;
    public GameObject warningUI;

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            sfxmanager.singleton.playSound(5);
            health = 0;
            PlayerController.singleton.anim.SetTrigger("dead");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        UIhealth[health].SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("musuh"))
        {
            sfxmanager.singleton.playSound(4);
            TakeDamage();
            warningUI.SetActive(true);
            StartCoroutine(turnOffWarning());
        }
        else if (collision.CompareTag("duri"))
        {
            sfxmanager.singleton.playSound(5);
            PlayerController.singleton.anim.SetTrigger("dead");
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator turnOffWarning()
    {
        yield return new WaitForSeconds(3);
        warningUI.SetActive(false);
    }
}
