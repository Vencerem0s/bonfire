using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    private float timeBtwShots;

    void Start()
    {
        
    }

    void Update()
    {
        LookAtMouseKlick();
        
    }

    private void LookAtMouseKlick()
    {
        if (Input.GetMouseButton(0))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        //GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);

        GameObject newArrow = Instantiate(arrow, shotPoint.position, transform.rotation);//shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.forward * launchForce;
    }
}
