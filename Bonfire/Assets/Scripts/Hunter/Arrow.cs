using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    //public float lifetime;
    //public float distance;
    //public int damage;
    //public LayerMask whatIsSolid;
    private Rigidbody2D rb;
    private Transform curobj;
    //private Transform target;
    public Transform shotPoint;
    [SerializeField] float speed = 20f;

    void Start()
    {
        //curobj = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //shotPoint = GameObject.Find("ShotPoint").GetComponentInParent<Transform>();*/
        Vector3 targ = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        rb.AddForce(new Vector2(targ.x, targ.y) * speed); // Короч force хуйня, надо что-то придумать, но я спать хочу
    }

    void Update()
    {
        //rb.velocity = transform.TransformDirection(shotPoint.position * speed);
        //transform.position = transform.position * speed * Time.deltaTime;
        //rb.AddForce(new Vector2(target.transform.position.x, target.transform.position.y));
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }*/
}
