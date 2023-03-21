using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // —сылка на Transform agro
    private GameObject player;
    public float speed = 2f; // —корость движени€ врага
    //public int hpEnemy;

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
        if (agro != player.transform)
        {
            speed = 2f;
        }
    }

    private void TakeAgro()
    {
        if (GameObject.Find("golem(Clone)"))
        {
            agro = GameObject.Find("golem(Clone)").GetComponent<Transform>();
        }
        else if (GameObject.Find("lightBolt(Clone)"))
        {
            agro = GameObject.Find("lightBolt(Clone)").GetComponent<Transform>();
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
