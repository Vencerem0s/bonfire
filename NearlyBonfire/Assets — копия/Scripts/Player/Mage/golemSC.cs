using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using System.Threading.Tasks;
using Unity.VisualScripting;
using System;
using static UnityEditor.Progress;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class golemSC : MonoBehaviour
{
    private Transform agro; // Ссылка на Transform agro
    //private GameObject[] enemy;

    //public GameObject explosionGolem;
    //private GameObject closest;

    //[SerializeField] private float hpGolem;

    private Animator gAnimator;

    private LiveParametrs curHealth;

    public float speed = 2f;

    private Vector3 direction;

    private NavMeshAgent agent;

    private bool _destroy;

    void Start()
    {
        _destroy = true;
        //StartCoroutine(BeforeStart());
        GameObjectsManager.Register(gameObject);
        GolemStun();

        agent = GetComponent<NavMeshAgent>();
        curHealth = GetComponent<LiveParametrs>();
        gAnimator = GetComponent<Animator>();
        GameEventManger.Stuned?.Invoke(4);
        AgroOnMe();
        //Instantiate(explosionGolem); //запуск префаба взрыва от появления

        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //golem = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (curHealth.health <= 0)
        {
            DeafaultAnim();
            _destroy = false;
            gAnimator.SetBool("Die", true);
            agent.SetDestination(transform.position);
        }
        else
        {
            Movement();
        }
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

        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemy = GameObjectsManager.GetGameObjectByTag("Enemy");
        /*GameObject[] enemyManger = GameObjectsManager.GetGameObjects<GameObject>();
        List<GameObject> enemy = new List<GameObject>();

        if (enemyManger == null)
        {
            return;
        }

        foreach (var entry in enemyManger)
        {
            if (entry.gameObject.tag == "Enemy")
            {
                enemy.Add(entry);
            }
        }*/

        float distance = 0f;
        Vector3 position = transform.position;

        //enemy.ToArray();

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

    private async void AgroOnMe()
    {
        while (_destroy)
        {
            GameEventManger.onPlayerThingAgro?.Invoke(gameObject.tag);
            await Task.Delay(1000);
        }
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.name == agro.name)
        {
            DeafaultAnim();
            //gAnimator.SetBool("Attack", true);//Анимация атаки
            speed = 0f;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.name == agro.name)
        {
            DeafaultAnim();//Отмена анимаций
            speed = 2f;
        }
    }*/

    private void GolemStun()
    {
        /*foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<TestEnemy>().Stun(2f);
        }*/
    }

    private void DeafaultAnim()
    {
        //gAnimator.SetBool("Idle", true);
        gAnimator.SetFloat("Walk", 2f);
    }

    /*IEnumerator BeforeStart()
    {
        speed = 0f;
        yield return new WaitForSeconds(2f);
        speed = 2f;
    }*/

    public void BeforeDie()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Mage>().GolemAura(false, null);
        GameObjectsManager.GetGameObjectByTag("Player")[0].GetComponent<Mage>().GolemAura(false, null);
        GameObjectsManager.Unregister(gameObject);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (GameObjectsManager.GetGameObjectByTag("lightBolt").Length > 0)
        {
            GameEventManger.onPlayerThingAgro?.Invoke("lightBolt");
        }
        else if (GameObjectsManager.GetGameObjectByTag("Player").Length > 0)
        {
            GameEventManger.onPlayerThingAgro?.Invoke("Player");
        }
    }
}