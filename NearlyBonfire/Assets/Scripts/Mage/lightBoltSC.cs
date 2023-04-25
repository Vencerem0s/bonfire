using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class lightBoltSC : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    public GameObject explosionAnim;

    private Enemy thisHealth;

    void Start()
    {
        GameObjectsManager.RegisterPlayers(gameObject);
        thisHealth = GetComponent<Enemy>();
    }
        
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > 56f)
        {
            Destroy(gameObject);
        }

        if (thisHealth.health <= 0)
        {
            Instantiate(explosionAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObjectsManager.UnregisterPlayers(gameObject);
    }
}
