using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
