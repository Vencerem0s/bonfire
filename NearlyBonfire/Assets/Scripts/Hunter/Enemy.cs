using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    //public GameObject deathPrefab;
    private float maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Instantiate(deathPrefab, transform); //запуск префаба после смерти
            Destroy(gameObject);
        }
        print("ouch");
    }

    public void TakeHealth(float healthpoint)
    {
        if ((health + healthpoint) >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthpoint;
        }
    }
    public void BloodLostAnimation()
    {
        //здесь запускаем анимацию потери крови
    }
}
