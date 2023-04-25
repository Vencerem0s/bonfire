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
            print($"���� {damage} �� {tag1}!");
            //��������� ����� �� ����
        }
        else if (other.gameObject.CompareTag(tag2))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            print($"���� {damage} �� {tag2}!");
            //��������� ����� �� ����
        }
        else if (other.gameObject.CompareTag(tag3))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            print($"���� {damage} �� {tag3}!");
            //��������� ����� �� ����
        }
    }  
}
