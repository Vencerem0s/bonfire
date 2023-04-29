using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBoltSC : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    public GameObject explosionAnim;

    private Enemy thisEnemy;

    void Start()
    {
        thisEnemy = GetComponent<Enemy>();
    }
        
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > 56f)
        {
            Destroy(gameObject);
        }

        if (thisEnemy.health <= 0)
        {
            Instantiate(explosionAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
