//Скрипт для мили НПС

/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
/*using UnityEngine.AI;
using System.Threading.Tasks;
using static UnityEditor.Experimental.GraphView.GraphView;*/

public class MeleeMovement : EnemyMovement
{
    /*private NavMeshAgent agent;
    private Animator gAnimator;*/
    
   /* protected override void Start()
    {
        //_stun = false;
        agent = GetComponent<NavMeshAgent>();
        gAnimator = GetComponent<Animator>();
    }*/

    protected override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(_stun == true)
        {
            agent.SetDestination(transform.position); //анимация стана
            return;
        }

        if (agro)
        {
            agent.SetDestination(agro.position);
            transform.LookAt(new Vector3(agro.position.x, 0f, agro.position.z));
            gAnimator.SetFloat("Walk", agent.remainingDistance);
        }
        else
        {
            gAnimator.SetFloat("Walk", 2f);
        }
    }
}