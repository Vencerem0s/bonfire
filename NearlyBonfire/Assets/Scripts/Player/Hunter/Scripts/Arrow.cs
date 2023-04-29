using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class Arrow : MonoBehaviour
{

    [SerializeField] float speed = 20f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
