using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health,maxHealth;
    public Image healthUI;

    public Animator animenemy;

    private void Start()
    {
        animenemy = GetComponent<Animator>();
        maxHealth = health;
    }


    public void TakeDamageEnemy(float damage)
    {
        health -= damage;
        healthUI.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            sfxmanager.singleton.playSound(3);
            animenemy.SetTrigger("enemy-dead");
            Destroy(gameObject,0.5f);
        }
    }
}
