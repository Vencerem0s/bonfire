using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeMovement : MonoBehaviour
{
    private Transform agro;
    [SerializeField] private float speed = 2f;
    private Vector3 direction;
    private NavMeshAgent agent;
    private Animator gAnimator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gAnimator = GetComponent<Animator>();
        StartPosition();
    }

    public virtual void StartPosition()
    {
        //тут задаем стартовую позицию врага, относительно правой и левой стороны экрана
    }

    void Update()
    {
        
    }
}