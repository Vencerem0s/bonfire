using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Hunter _hunter;

    private void Start()
    {
        StartCoroutine(TrapLifeTime());
    }

    private IEnumerator TrapLifeTime()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}

  
