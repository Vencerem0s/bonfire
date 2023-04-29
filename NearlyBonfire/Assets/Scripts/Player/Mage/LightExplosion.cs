using UnityEngine;

public class LightExplosion : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().Stun(2);
        }
    }
}
