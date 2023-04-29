using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
<<<<<<< HEAD:NearlyBonfire/Assets/Scripts/Hunter/Scripts/Enemy.cs
    public float _health;//{ get; private set; }
    public GameObject deathPrefab;

    //public float health;
=======
    public float health;
>>>>>>> a5a5a81cc24d7df3b1de30d229438dc94e9c9984:NearlyBonfire/Assets/Scripts/Player/Hunter/Scripts/Enemy.cs
    //public GameObject deathPrefab;
    private float maxHealth;
    
    private int _myIndex;

    private void Start()
    {
<<<<<<< HEAD:NearlyBonfire/Assets/Scripts/Hunter/Scripts/Enemy.cs
        _health = 100f;
        maxHealth = _health;
        
=======
        GameObjectsManager.Register(gameObject);
        maxHealth = health;
>>>>>>> a5a5a81cc24d7df3b1de30d229438dc94e9c9984:NearlyBonfire/Assets/Scripts/Player/Hunter/Scripts/Enemy.cs
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

    private void OnDestroy()
    {
        GameObjectsManager.Unregister(gameObject);
    }
}
