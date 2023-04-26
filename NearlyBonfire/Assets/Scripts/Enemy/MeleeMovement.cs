using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MeleeMovement : MonoBehaviour
{
    private Transform agro;
    private NavMeshAgent agent;
    private Animator gAnimator;
    private bool _stun;

    void Start()
    {
        _stun = false;
        agent = GetComponent<NavMeshAgent>();
        gAnimator = GetComponent<Animator>();
        StartPosition();
        TakeAgro("Player");
        GameEventManger.onPlayerThingAgro += TakeAgro;
        GameEventManger.Stuned += Stun;
    }

    public virtual void StartPosition()
    {
        //тут задаем стартовую позицию врага, относительно правой и левой стороны экрана
    }

    void Update()
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

    private void TakeAgro(string agroEnemy)
    {
        agro = GameObjectsManager.GetGameObjectByTag(agroEnemy)[0].GetComponent<Transform>();
    }

    private async void Stun(int duration)
    {
        _stun = true; Debug.Log("waiting");
        await Task.Delay(duration * 1000);
        _stun = false; Debug.Log("stop waiting");
    }

    private void OnDestroy()
    {
        GameEventManger.onPlayerThingAgro -= TakeAgro;
        GameEventManger.Stuned -= Stun;
    }
}