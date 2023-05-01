//скрипт для рендж НПС
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : EnemyMovement
{
    /*[SerializeField] private bool onPointNPC;*/ //если булево Тру, то НПС ходит за игроком, если Фолс, то НПС всегда стоит на месте
    [SerializeField] private GameObject _shootObject; //объект, которым стреляет НПС
    [SerializeField] private Transform _transformDeparture; //откуда стреляет
    //[SerializeField] private float xPosition, yPosition, zPosition;

    /*protected override void Start()
    {
        if (onPointNPC)
        {
            StartPosition();
        }
    }*/

    protected override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_stun == true)
        {
            agent.SetDestination(transform.position); //анимация стана
            return;
        }

        if (agro)
        {
            agent.SetDestination(agro.position);
            RangeState();
        }
    }

    private void RangeState()
    {
        transform.LookAt(new Vector3(agro.position.x, 0f, agro.position.z));
        gAnimator.SetFloat("State", agent.remainingDistance);
    }

    /*protected override void StartPosition()
    {
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }*/

    public void ShootRangeNPC() //вызывать из анимации выстрела
    {
        if(_transformDeparture == null)
        {
            Instantiate(_shootObject, new Vector3(agro.position.x, _shootObject.transform.position.y, agro.position.z), _shootObject.transform.rotation);
        }
    }
}
