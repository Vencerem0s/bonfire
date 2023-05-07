using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float _health;//{ get; private set; }
    public GameObject deathPrefab;

    public float _health;


    //public GameObject deathPrefab;
    private float maxHealth;
    
    private int _myIndex;

    private void Start()
    {
        _health = 100f;
        maxHealth = _health;
        
        GameObjectsManager.Register(gameObject);
        maxHealth = _health;
        _health = 100f;
        maxHealth = _health;
        
        GameObjectsManager.Register(gameObject);
        maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            //Instantiate(deathPrefab, transform); //������ ������� ����� ������
            Destroy(gameObject);
        }
        print("ouch");
    }

    public void TakeHealth(float healthpoint)
    {
        if ((_health + healthpoint) >= maxHealth)
        {
            _health = maxHealth;
        }
        else
        {
            _health += healthpoint;
        }
    }
    public void BloodLostAnimation()
    {
        //����� ��������� �������� ������ �����
    }

    private void OnDestroy()
    {
        GameObjectsManager.Unregister(gameObject);
    }
}
