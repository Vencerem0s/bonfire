using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // —сылка на Transform agro
    private GameObject player;
    public float speed = 2f; // —корость движени€ врага

    private Vector3 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        TakeAgro();
        EnemMovement();
    }

    private void EnemMovement()
    {
        if (agro)
        {
            direction = agro.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;

        }
    }

    private void TakeAgro()
    {
        if (GameObject.Find("Golem"))
        {
            agro = GameObject.Find("Golem").GetComponent<Transform>();
        }
        else if (GameObject.Find("lightBolt"))
        {
            agro = GameObject.Find("lightBolt").GetComponent<Transform>();
        }
        else
        {
            agro = player.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 2f;
        }
    }
}
