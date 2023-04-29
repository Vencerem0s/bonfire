//Задаем агро для НПС, вызываем стан и определяем его длительность, определяем стартовую позицию

/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    protected bool _stun;
    public Transform agro;
    protected NavMeshAgent agent;
    public Animator gAnimator;

    protected virtual void Start()
    {
        _stun = false;
        StartPosition();
        GameEventManger.onPlayerThingAgro += TakeAgro;
        GameEventManger.Stuned += Stun;
        TakeAgro("Player");
        agent = GetComponent<NavMeshAgent>();
        gAnimator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    public virtual void StartPosition()
    {
        //тут задаем стартовую позицию врага, относительно правой и левой стороны экрана
    }

    public virtual void TakeAgro(string agroEnemy)
    {
        agro = GameObjectsManager.GetGameObjectByTag(agroEnemy)[0].GetComponent<Transform>();
    }

    public virtual async void Stun(int duration)
    {
        await Task.Delay(duration * 1000);
    }
    
    protected virtual void OnDestroy()
    {
        GameEventManger.onPlayerThingAgro -= TakeAgro;
        GameEventManger.Stuned -= Stun;
    }
}
