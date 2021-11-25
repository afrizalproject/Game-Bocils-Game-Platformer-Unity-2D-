using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health,maxHealth;
    public Image healthUI;

    private void Start()
    {
        maxHealth = health;
    }


    public void TakeDamageEnemy(float damage)
    {
        health -= damage;
        healthUI.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
