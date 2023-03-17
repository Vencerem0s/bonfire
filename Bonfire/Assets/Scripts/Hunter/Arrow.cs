using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public float lifetime;
    //public float distance;
    //public int damage;
    //public LayerMask whatIsSolid;
    
    [SerializeField] float speed = 20f;

    /*void Start()
    {
        Destroy(gameObject, 2f);
    }*/

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*if (collision.CompareTag("Enemy"))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }*/

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
