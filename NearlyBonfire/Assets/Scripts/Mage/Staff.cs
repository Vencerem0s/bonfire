//скрипт по атаке посохом, выpывается из функции Attacks()

using System.Collections;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public Transform sphereFireStartPoint;
    public GameObject darkSphere;

    private bool sphereFire;

    public float dps;
    private float maxDps, cda;
    //public Transform laserFireEndPoint;
    //public LineRenderer m_lineRenderer;

    private void Start()
    {
        sphereFire = true;
        cda = 0f;
        maxDps = 20f;
        //m_lineRenderer.enabled = false;
    }

    /*private void Update()
    {
        //ShootLaser();
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

    public void StaffSpell()
    {
        if (sphereFire == false)
        {
            return;
        }
        //print("zaryad");
        
        dps += 0.01f;
        cda += 0.01f;
        
        if (dps >= maxDps)
        {
            dps = maxDps;
        }

        if (cda >= 2f)
        {
            cda = 2f;
        }
        //из этих скриптов нужно осуществить плавное появление луча
        //m_lineRenderer.enabled = true;
    }

    public void StaffSpellOff()
    {
        //здесь два звука, один выстрела при true, второй звук пфф, как при паре, если false
        if (sphereFire)
        {
            //print($"dps = {dps} и cda {cda}");
            Instantiate(darkSphere, sphereFireStartPoint.position, transform.rotation);
            StartCoroutine(CDSphere());
        }
        else
        {

        }
        //m_lineRenderer.enabled = false;
    }

    IEnumerator CDSphere()
    {
        sphereFire = false;
        yield return new WaitForSeconds(cda); //yield return new WaitForSeconds(2f);
        cda = dps = 0f;
        sphereFire = true;
    }
}
