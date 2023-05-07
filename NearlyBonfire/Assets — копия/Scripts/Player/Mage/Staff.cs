//скрипт по атаке посохом, вызывалась из функции Attacks()

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    /*public Transform sphereFireStartPoint;
    public GameObject darkSphere, player;

    private bool sphereFire, sphereFireUp;

    public float dps, cda;
    private float maxDps;
    private bool shoot;
    private Animator chAnimator;
    private IlyaMovement speedPlayer;
    //public Transform laserFireEndPoint;
    //public LineRenderer m_lineRenderer;

    private void Start()
    {
        speedPlayer = player.GetComponent<IlyaMovement>();
        sphereFire = true;
        sphereFireUp = false;
        chAnimator = player.GetComponent<Animator>();
        cda = 0f;
        maxDps = 20f;
        //m_lineRenderer.enabled = false;
    }*/

    /*private void Update()
    {
        //ShootLaser();
        if (Input.GetMouseButtonDown(0) && sphereFire)
        {
            sphereFire = false;
            shoot = true;
            sphereFireUp = true;
            chAnimator.SetBool("Run", false);
            chAnimator.SetBool("Attack", true);
            StartCoroutine(StaffSpell());
        }
        if (Input.GetMouseButtonUp(0) && sphereFireUp)
        {
            sphereFireUp = false;
            shoot = false;
            chAnimator.SetFloat("spellx", 1);
            chAnimator.SetFloat("spelly", 1);
            speedPlayer.SpellDuration(2.5f);
            //StartCoroutine(CDSphere());
            //StaffSpellOff();
        }
    }*/

    /*void ShootLaser()
    {
        m_lineRenderer.SetPosition(0, laserFireStartPoint.position);
        m_lineRenderer.SetPosition(1, laserFireEndPoint.position);

        Vector2 direction = laserFireEndPoint.position - laserFireStartPoint.position;

        RaycastHit2D _hit = Physics2D.Raycast(laserFireStartPoint.position, direction.normalized, direction.magnitude);

        if(_hit && _hit.collider.name != "Aura")
        {
            m_lineRenderer.SetPosition(1, _hit.point);
        }
    }*/

    //public void StaffSpell()
    /*IEnumerator StaffSpell()
    {
        *//*if (sphereFire == false)
        {
            return;
        }*//*
        //print("zaryad");

        *//*chAnimator.SetFloat("spellx", 0);
        chAnimator.SetFloat("spelly", 0);*//*
        while (shoot)
        {
            *//*if (sphereFire == false)
            {
                break;
            }*//*

            speedPlayer.speedMove = 0f;

            dps += 0.01f;
            cda += 0.01f;

            if (dps >= maxDps)
            {
                dps = maxDps;
            }

            if (cda >= 2f)
            {
                *//*sphereFireUp = false;
                shoot = false;
                chAnimator.SetFloat("spellx", 1);
                chAnimator.SetFloat("spelly", 1);
                speedPlayer.SpellDuration(2.5f);
                StartCoroutine(CDSphere());*//*
                cda = 2f;
                //StartCoroutine(CDSphere());
            }
            yield return new WaitForSeconds(0.001f);
        }
        //из этих скриптов нужно осуществить плавное появление луча
        //m_lineRenderer.enabled = true;
    }*/

    /*public void StaffSpellOff()
    {
        //здесь два звука, один выстрела при true, второй звук пфф, как при паре, если false
        if (sphereFireUp)
        {
            //print($"dps = {dps} и cda {cda}");
            //shoot = false;
            //Instantiate(darkSphere, sphereFireStartPoint.position, transform.rotation);
            sphereFireUp = false;
            shoot = false;
            chAnimator.SetFloat("spellx", 1);
            chAnimator.SetFloat("spelly", 1);
            speedPlayer.SpellDuration(2f);
            StartCoroutine(CDSphere());
        }
        *//*else
        {
            chAnimator.SetBool("Attack", false);
            return;
        }*//*
        //m_lineRenderer.enabled = false;
    }*/

    /*IEnumerator CDSphere()
    {
        //yield return new WaitForSeconds(cda);
        yield return new WaitForSeconds(2.2f);
        cda = 0f;
        dps = 0f;
        sphereFire = true;
    }*/

    /*public void StaffSphere()
    {
        sphereFire = true;
    }*/
}
