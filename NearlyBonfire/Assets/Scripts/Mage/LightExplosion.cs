using UnityEngine;

public class LightExplosion : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<TestEnemy>().Stun(2f);
        }
    }
}
