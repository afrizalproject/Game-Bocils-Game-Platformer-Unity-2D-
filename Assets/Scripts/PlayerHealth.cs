using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] UIhealth;

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            PlayerController.singleton.anim.SetTrigger("dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        UIhealth[health].SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("musuh"))
        {
            TakeDamage();
            PlayerController.singleton.anim.SetTrigger("hit");
        }
        else if (collision.CompareTag("duri"))
        {
            PlayerController.singleton.anim.SetTrigger("dead");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
