using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDPS : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string tag1, tag2, tag3;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag1))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            print($"Урон {damage} по {tag1}!");
            //нанесение урона по цели
        }
        else if (other.gameObject.CompareTag(tag2))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            print($"Урон {damage} по {tag2}!");
            //нанесение урона по цели
        }
        else if (other.gameObject.CompareTag(tag3))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            print($"Урон {damage} по {tag3}!");
            //нанесение урона по цели
        }
    }  
}
