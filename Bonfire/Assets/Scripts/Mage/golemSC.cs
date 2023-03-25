using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class golemSC : MonoBehaviour
{
    public Transform agro; // Ссылка на Transform agro
    private GameObject[] enemy;
    public GameObject explosionGolem;
    private GameObject closest;

    public float speed = 2f;

    private Vector3 direction;

    void Start()
    {
        GolemStun();
        //Instantiate(explosionGolem); //запуск префаба взрыва от появления

        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //golem = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (agro)
        {
            direction = agro.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            FindClosestEnemy();
        }
    }

    private void FindClosestEnemy()
    {
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
            //Анимация атаки
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.name == agro.name)
        {
            //Анимация атаки
            speed = 2f;
        }
    }

    private void GolemStun()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gameObj.GetComponent<TestEnemy>().Stun(2f);
        }
    }
}
