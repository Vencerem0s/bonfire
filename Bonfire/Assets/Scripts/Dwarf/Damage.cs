using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject viewpos;
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("awdwadwa");
        if (collision.CompareTag("attach"))// && GetComponent<SpriteRenderer>().sprite.name == "Circle")
        {
            Debug.Log("awdwadwa");
            viewpos.GetComponent<XrossingEnemy>().DamageDeal();
        }
    }
}
