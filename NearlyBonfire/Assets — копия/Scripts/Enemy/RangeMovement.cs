//������ ��� ����� ���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : EnemyMovement
{
    /*[SerializeField] private bool onPointNPC;*/ //���� ������ ���, �� ��� ����� �� �������, ���� ����, �� ��� ������ ����� �� �����
    [SerializeField] private GameObject _shootObject; //������, ������� �������� ���
    [SerializeField] private Transform _transformDeparture; //������ ��������
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
            agent.SetDestination(transform.position); //�������� �����
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

    public void ShootRangeNPC() //�������� �� �������� ��������
    {
        if(_transformDeparture == null)
        {
            Instantiate(_shootObject, new Vector3(agro.position.x, _shootObject.transform.position.y, agro.position.z), _shootObject.transform.rotation);
        }
    }
}
