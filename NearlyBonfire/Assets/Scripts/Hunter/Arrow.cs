using UnityEngine;
using static UnityEditor.Progress;

public class Arrow : MonoBehaviour
{
    
    [SerializeField] float speed = 20f;


    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
