using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(15);
            print($"Урон голема!");
            //нанесение урона по цели
        }
    }  
}
