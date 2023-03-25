using System.Collections;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // —сылка на Transform agro
    private GameObject player;
    public float speed = 2f; // —корость движени€ врага
    private Enemy enemy;
    private Bow bow;

    private Vector3 direction;

    private void Start()
    {
        bow = GameObject.Find("Bow").GetComponent<Bow>();
        enemy = GetComponent<Enemy>();
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

   IEnumerator Stun()
    {
        speed = 0f;
        enemy.TakeDamage(50);
        yield return new WaitForSeconds(2f);
        speed = 2f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Hunter>().takeDamage = true;
            //StartCoroutine(player.GetComponent<HunterSkills>().DelayTime());
            speed = 0f;
        }else if (other.gameObject.CompareTag("Boar"))
        {
            StartCoroutine(Stun());
        }else if (other.gameObject.CompareTag("Arrow"))
        {
            enemy.TakeDamage(bow.arrowDamage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 2f;
            player.GetComponent<Hunter>().takeDamage = false;
            player.GetComponent<HunterSkills>().StartAccumulationOfConcentration();
        }
    }
}
