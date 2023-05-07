/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class ColliderDPS : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string _typeDamage, tag1, tag2, tag3;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag1))
        {
            other.GetComponent<LiveParametrs>().TakeDamage(_typeDamage, damage);
        }
        else if (other.gameObject.CompareTag(tag2))
        {
            other.GetComponent<LiveParametrs>().TakeDamage(_typeDamage, damage);
        }
        else if (other.gameObject.CompareTag(tag3))
        {
            other.GetComponent<LiveParametrs>().TakeDamage(_typeDamage, damage);
        }
        /*if (other.TryGetComponent(out LiveParametrs parametrs))
        {
            parametrs.TakeDamage(_typeDamage, damage);
        }*/
    }  
}
