using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class golemSC : MonoBehaviour
{
    private Transform agro; // Ссылка на Transform agro
    private GameObject[] enemy;

    //public GameObject explosionGolem;
    //private GameObject closest;

    //[SerializeField] private float hpGolem;

    private Animator gAnimator;

    private Enemy curHealth;

    public float speed = 2f;

    private Vector3 direction;

    private NavMeshAgent agent;

    void Start()
    {
        //StartCoroutine(BeforeStart());
        GolemStun();

        agent = GetComponent<NavMeshAgent>();
        curHealth = GetComponent<Enemy>();
        gAnimator = GetComponent<Animator>();
        //Instantiate(explosionGolem); //запуск префаба взрыва от появления

        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //golem = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (curHealth._health <= 0)
        {
            DeafaultAnim();
            gAnimator.SetBool("Die", true);
            print("dead");
        }
        Movement();
    }

    private void Movement()
    {
        if (agro)
        {
            /*direction = agro.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;*/
            agent.SetDestination(agro.position);
            transform.LookAt(new Vector3(agro.position.x, 0f, agro.position.z));
            //gAnimator.SetBool("Idle", false);
            gAnimator.SetFloat("Walk", agent.remainingDistance);
        }
        else
        {
            FindClosestEnemy();
        }
    }

    private void FindClosestEnemy()
    {
        DeafaultAnim();

        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy == null)
        {
            return;
        }

        float distance = 0f;
        Vector3 position = transform.position;
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance > distance)
            {
                agro = go.transform;
                distance = curDistance;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.name == agro.name)
        {
            DeafaultAnim();
            gAnimator.SetBool("Attack", true);//Анимация атаки
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.name == agro.name)
        {
            DeafaultAnim();//Отмена анимаций
            speed = 2f;
        }
    }

    private void GolemStun()
    {
        /*foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<TestEnemy>().Stun(2f);
        }*/
    }

    private void DeafaultAnim()
    {
        gAnimator.SetBool("Idle", true);
    }

    IEnumerator BeforeStart()
    {
        speed = 0f;
        yield return new WaitForSeconds(2f);
        speed = 2f;
    }

    public void BeforeDie()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Mage>().GolemAura(false, null);
        Destroy(gameObject);
    }
}