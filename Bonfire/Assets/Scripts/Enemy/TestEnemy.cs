using System.Collections;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Transform agro; // Ссылка на Transform agro
    private GameObject player;
<<<<<<< HEAD
    public float speed = 2f; // Скорость движения врага
    private Enemy enemy;
    private Bow bow;
=======
    public float speed; // Скорость движения врага
    
    private float stun;
>>>>>>> 044ecca3493a06cb1459e9b092e3e2628fe00c55

    private Vector3 direction;

    [SerializeField] private float damage;

    private void Start()
    {
<<<<<<< HEAD
        bow = GameObject.Find("Bow").GetComponent<Bow>();
        enemy = GetComponent<Enemy>();
=======
        stun = 0f;
>>>>>>> 044ecca3493a06cb1459e9b092e3e2628fe00c55
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (stun > 0f)
        {
            return;
        }
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

<<<<<<< HEAD
   IEnumerator Stun()
    {
        speed = 0f;
        enemy.TakeDamage(50);
        yield return new WaitForSeconds(2f);
        speed = 2f;
=======
    public void Stun(float secs)
    {
        stun = secs;
        StartCoroutine(StunCoroutine());
    }

    IEnumerator StunCoroutine()
    {
        //запуск анимации стана
        yield return new WaitForSeconds(stun);
        //запуск анимации ходьбы
        stun = 0f;
>>>>>>> 044ecca3493a06cb1459e9b092e3e2628fe00c55
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
<<<<<<< HEAD
            player.GetComponent<Hunter>().takeDamage = true;
            //StartCoroutine(player.GetComponent<HunterSkills>().DelayTime());
=======
            //анимация атаки
>>>>>>> 044ecca3493a06cb1459e9b092e3e2628fe00c55
            speed = 0f;
        }else if (other.gameObject.CompareTag("Boar"))
        {
            StartCoroutine(Stun());
        }else if (other.gameObject.CompareTag("Arrow"))
        {
            enemy.TakeDamage(bow.arrowDamage);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("golem") || other.gameObject.CompareTag("lightBolt"))
        {
            //анимация ходьбы
            speed = 2f;
            player.GetComponent<Hunter>().takeDamage = false;
            player.GetComponent<HunterSkills>().StartAccumulationOfConcentration();
        }
    }
}
