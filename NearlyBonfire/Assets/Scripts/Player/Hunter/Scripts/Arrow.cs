using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class Arrow : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    [SerializeField] bool isArrow = true;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > 56f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && isArrow)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
