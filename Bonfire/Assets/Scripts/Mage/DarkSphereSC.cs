//скрипт получает дпс с посоха и наносит дпс врагу

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSphereSC : MonoBehaviour
{
    
    [SerializeField] float speed = 2f;

    private float curDps;

    void Start()
    {
        curDps = GameObject.Find("Staff").GetComponent<Staff>().dps;
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(curDps);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Mage>().TakeMana(5f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
