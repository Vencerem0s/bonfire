//Задаем агро для НПС, вызываем стан и определяем его длительность, определяем стартовую позицию

/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;
//using System;

public class EnemyMovement : MonoBehaviour
{
    protected bool _stun;
    public Transform agro;
    protected NavMeshAgent agent;
    public Animator gAnimator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gAnimator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        _stun = false;
        GameEventManger.onPlayerThingAgro += TakeAgro;
        GameEventManger.Stuned += Stun;
        StartCoroutine(WaitBeforeStart());
        
    }

    private void Awake()
    {
        StartPosition();
    }
    protected virtual void Update()
    {

    }

    protected virtual void StartPosition()
    {
        int _random = Random.Range(1, 2);
        float _zPos = Random.Range(-13f, 1f);

        if (_random == 1)
        {
            Vector3 _sidePos = GameObjectsManager.GetGameObjectByTag("SideCamera")[0].GetComponent<Transform>().position;
            transform.position = new Vector3 (_sidePos.x, 0f, _sidePos.z + _zPos);
        }
        else
        {
            Vector3 _sidePos = GameObjectsManager.GetGameObjectByTag("SideCamera")[1].GetComponent<Transform>().position;
            transform.position = new Vector3(_sidePos.x, 0f, _sidePos.z + _zPos);
        }
    }

    public virtual void TakeAgro(string agroEnemy)
    {
        agro = GameObjectsManager.GetGameObjectByTag(agroEnemy)[0].GetComponent<Transform>();
    }

    public virtual async void Stun(int duration)
    {
        _stun = true;
        await Task.Delay(duration * 1000);
        _stun = false;
    }
    
    protected virtual void OnDestroy()
    {
        GameEventManger.onPlayerThingAgro -= TakeAgro;
        GameEventManger.Stuned -= Stun;
    }

    private IEnumerator WaitBeforeStart()
    {
        yield return new WaitForSeconds(1f);
        TakeAgro("Player");
    }
}
