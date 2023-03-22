using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class golemSC : MonoBehaviour
{
    public Transform agro; // Ссылка на Transform agro
    private GameObject[] enemy;

    private GameObject closest;
    //private NavMeshAgent golem;

    public float speed = 2f;

    private Vector3 direction;

    void Start()
    {
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //golem = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //FindClosestEnemy();
        //ChooseSmash();
        //StartCoroutine(GetClosestTarget());
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
            //StartCoroutine(GetClosestTarget());
        }
    }

    private void FindClosestEnemy()//Transform FindClosestEnemy()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy == null)
        {
            return;
        }

        float distance = 0f;//Mathf.Infinity;
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
        //return agro;
    }

    /*private void ChooseSmash()
    {
        if (GameObject.Find("Golem(Clone)"))
        {
            agro = GameObject.Find("Golem(Clone)").GetComponent<Transform>();
        }
        else if (GameObject.Find("lightBolt(Clone)"))
        {
            agro = GameObject.Find("lightBolt(Clone)").GetComponent<Transform>();
        }
        else
        {
            agro = enemy.transform;
        }
    }*/

    /*IEnumerator GetClosestTarget()
    {
        GameObject[] gameobj = GameObject.FindGameObjectsWithTag("Enemy");
        float tmpDist = float.MaxValue;
        GameObject currentTarget = null;
        for (int i = 0; i < gameobj.Length; i++)
        {
            if (golem.SetDestination(gameobj[i].transform.position))
            {
                //ждем пока вычислится путь до цели
                while (golem.pathPending)
                {
                    yield return null;
                }
                Debug.Log(golem.pathStatus.ToString());
                // проверяем, можно ли дойти до цели
                if (golem.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    float pathDistance = 0;
                    //вычисляем длину пути
                    pathDistance += Vector3.Distance(transform.position, golem.path.corners[0]);
                    for (int j = 1; j < golem.path.corners.Length; j++)
                    {
                        pathDistance += Vector3.Distance(golem.path.corners[j - 1], golem.path.corners[j]);
                    }

                    if (tmpDist > pathDistance)
                    {
                        tmpDist = pathDistance;
                        currentTarget = gameobj[i];
                        golem.ResetPath();
                    }
                }
                else
                {
                    Debug.Log("невозможно дойти до " + gameobj[i].name);
                }

            }

        }
        if (currentTarget != null)
        {
            //golem.SetDestination(currentTarget.transform.position);
            agro = currentTarget.transform;
            //... дальше ваша логика движения к цели
        }
    }*/
}
